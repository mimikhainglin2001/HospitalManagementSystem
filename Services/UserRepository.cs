namespace HospitalManagementSystem.Services;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
    }

    public async Task<List<ApplicationUser>> GetUsersAsync()
    {
        // get all users with their roles
        var users = await _context.Users.ToListAsync();
        return users;
    }

    public async Task<ApplicationUser?> GetUserByIdAsync(string id)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<ApplicationUser> AddUserAsync(ApplicationUser user)
    {
        // add users
        var result = await _userManager.CreateAsync(user, user.PasswordHash);
        if (!result.Succeeded)
        {
            var errors = string.Join("; ", result.Errors.Select(e => e.Description));
            throw new InvalidOperationException($"Failed to create user: {errors}");
        }
        return user;
    }

    public async Task<ApplicationUser?> UpdateUserAsync(ApplicationUser user)
    {
        // update user
        var existing = await _context.Users.FindAsync(user.Id);

        if (existing == null) return null;

        existing.FirstName = user.FirstName;
        existing.LastName = user.LastName;
        existing.Email = user.Email;
        existing.Address = user.Address;
        existing.EmergencyPhoneNumber = user.EmergencyPhoneNumber;
        existing.DateOfBirth = user.DateOfBirth;
        existing.MotherName = user.MotherName;
        existing.FatherName = user.FatherName;
        existing.NationalIdNumber = user.NationalIdNumber;
        existing.GenderId = user.GenderId;
        existing.BloodGroupId = user.BloodGroupId;
        existing.MaritalStatusId = user.MaritalStatusId;
        existing.UserName = user.UserName;
        existing.PhoneNumber = user.PhoneNumber;
        var result = await _userManager.UpdateAsync(existing);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException("Failed to update user.");
        }
        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<ApplicationUser?> DeleteUserAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null) return null;

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            var errors = string.Join("; ", result.Errors.Select(e => e.Description));
            throw new InvalidOperationException($"Failed to delete user: {errors}");
        }
        return user;
    }
}