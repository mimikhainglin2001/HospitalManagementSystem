using HospitalManagementSystem.Data;

namespace HospitalManagementSystem.Interfaces;
public interface IUserRepository
{
    Task<List<ApplicationUser>> GetUsersAsync();
    Task<ApplicationUser?> GetUserByIdAsync(string id);
    Task<ApplicationUser> AddUserAsync(ApplicationUser user);
    Task<ApplicationUser?> UpdateUserAsync(ApplicationUser user);
    Task<ApplicationUser?> DeleteUserAsync(string id);

}