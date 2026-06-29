using HospitalManagementSystem.Models;
namespace HospitalManagementSystem.Interfaces
{
    public interface IAppointmentSlotRepository
    {
    Task<List<AppointmentSlot>> GetAppointmentSlotsAsync();
    Task<AppointmentSlot?> GetAppointmentSlotByIdAsync(int id);
    Task<AppointmentSlot> AddAppointmentSlotAsync(AppointmentSlot appointmentslot);
    Task<AppointmentSlot?> UpdateAppointmentSlotAsync(AppointmentSlot appointmentslot);
    Task<AppointmentSlot?> DeleteAppointmentSlotAsync(int id);
    }
}