using HospitalManagementSystem.Components;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Services
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly NumberSeriesGenerationService _numberseries;


        public AppointmentRepository(ApplicationDbContext context, NumberSeriesGenerationService numberseries)
        {
            _context = context;
            _numberseries = numberseries;
        }

        public async Task<List<Appointment>> GetAppointmentsAsync()
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Slot)
                .Include(a => a.Priority)
                .Include(a => a.PaymentMode)
                .Include(a => a.Status)
                .Include(a => a.CreatedBy)
                .Include(a => a.ModifiedBy)
                .ToListAsync();
        }

        public async Task<Appointment?> GetAppointmentByIdAsync(int id)
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Slot)
                .Include(a => a.Priority)
                .Include(a => a.PaymentMode)
                .Include(a => a.Status)
                .Include(a => a.CreatedBy)
                .Include(a => a.ModifiedBy)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Appointment> AddAppointmentAsync(Appointment appointment)
        {
            appointment.AppointmentNo = await _numberseries.GenerateAppointmentNumberAsync();
            appointment.CreatedOn = DateTime.UtcNow;
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment?> UpdateAppointmentAsync(Appointment appointment)
        {
            var existing = await _context.Appointments.FindAsync(appointment.Id);
            if (existing == null) return null;

            existing.PatientId = appointment.PatientId;
            existing.DoctorId = appointment.DoctorId;
            existing.SlotId = appointment.SlotId;
            existing.AppointmentDate = appointment.AppointmentDate;
            existing.PriorityId = appointment.PriorityId;
            existing.PaymentModeId = appointment.PaymentModeId;
            existing.StatusId = appointment.StatusId;
            existing.Address = appointment.Address;
            existing.Remarks = appointment.Remarks;
            existing.ModifiedOn = DateTime.UtcNow;
            existing.ModifiedById = appointment.ModifiedById;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<Appointment?> DeleteAppointmentAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return null;

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }
        
    }
}