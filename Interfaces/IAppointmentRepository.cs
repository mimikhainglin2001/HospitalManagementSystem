using HospitalManagementSystem.Models;
namespace HospitalManagementSystem.Interfaces
{
    public interface IAppointmentRepository
    {
    Task<List<Appointment>> GetAppointmentsAsync();
    Task<Appointment?> GetAppointmentByIdAsync(int id);
    Task<Appointment> AddAppointmentAsync(Appointment appointment);
    Task<Appointment?> UpdateAppointmentAsync(Appointment appointment);
    Task<Appointment?> DeleteAppointmentAsync(int id);
    }
}