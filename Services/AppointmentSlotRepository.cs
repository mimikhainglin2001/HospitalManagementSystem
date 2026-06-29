namespace HospitalManagementSystem.Services;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
public class AppointmentSlotRepository : IAppointmentSlotRepository
{
    private readonly ApplicationDbContext _context;

    public AppointmentSlotRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<AppointmentSlot>> GetAppointmentSlotsAsync()
    {
        return await _context.AppointmentSlots
            .Include(s => s.Doctor)
            .Include(s => s.Shift)
            .Include(s => s.Status)
            .Include(s => s.CreatedBy)
            .Include(s => s.ModifiedBy)
            .ToListAsync();
    }

    public async Task<AppointmentSlot?> GetAppointmentSlotByIdAsync(int id)
    {
        return await _context.AppointmentSlots
            .Include(s => s.Doctor)
            .Include(s => s.Shift)
            .Include(s => s.Status)
            .Include(s => s.CreatedBy)
            .Include(s => s.ModifiedBy)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<AppointmentSlot> AddAppointmentSlotAsync(AppointmentSlot appointmentslot)
    {
        appointmentslot.CreatedOn = DateTime.UtcNow;
        await _context.AppointmentSlots.AddAsync(appointmentslot);
        await _context.SaveChangesAsync();
        return appointmentslot;
    }

    public async Task<AppointmentSlot?> UpdateAppointmentSlotAsync(AppointmentSlot appointmentslot)
    {
        var existing = await _context.AppointmentSlots.FindAsync(appointmentslot.Id);
        if (existing == null) return null;

        existing.DoctorId = appointmentslot.DoctorId;
        existing.ShiftId = appointmentslot.ShiftId;
        existing.StartTime = appointmentslot.StartTime;
        existing.EndTime = appointmentslot.EndTime;
        existing.StatusId = appointmentslot.StatusId;
        existing.ModifiedOn = DateTime.UtcNow;
        existing.ModifiedById = appointmentslot.ModifiedById;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<AppointmentSlot?> DeleteAppointmentSlotAsync(int id)
    {
        var appointmentslot = await _context.AppointmentSlots.FindAsync(id);
        if (appointmentslot == null) return null;

        _context.AppointmentSlots.Remove(appointmentslot);
        await _context.SaveChangesAsync();
        return appointmentslot;
    }
}
