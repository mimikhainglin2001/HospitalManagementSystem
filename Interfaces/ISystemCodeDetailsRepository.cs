using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
namespace HospitalManagementSystem.Interfaces;

public interface ISystemCodeDetailsRepository
{
    Task<List<SystemCodeDetail>> GetSystemCodeDetailsAsync();
    Task<SystemCodeDetail?> GetSystemCodeDetailByIdAsync(int id);
    Task<SystemCodeDetail> AddSystemCodeDetailAsync(SystemCodeDetail systemCodeDetail);
    Task<SystemCodeDetail?> UpdateSystemCodeDetailAsync(SystemCodeDetail systemCodeDetail);
    Task<SystemCodeDetail?> DeleteSystemCodeDetailAsync(int id);
    Task<List<SystemCodeDetail>> GetSystemCodeDetailsByCodeAsync(string code);

}