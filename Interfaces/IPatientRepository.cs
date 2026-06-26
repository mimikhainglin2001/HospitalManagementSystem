using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Interfaces
{
    public interface IPatientRepository
{
    Task<List<Patient>> GetPatientsAsync();
    Task<Patient?> GetPatientByIdAsync(int id);
    Task<Patient> AddPatientAsync(Patient patient);
    Task<Patient?> UpdatePatientAsync(Patient patient);
    Task<Patient?> DeletePatientAsync(int id);
}
}