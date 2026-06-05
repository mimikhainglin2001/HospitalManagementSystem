namespace HospitalManagementSystem.Services;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationDbContext _context;

    public DepartmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Department>> GetDepartmentsAsync()
    {
        return await _context.Departments
            .Include(d => d.CreatedBy)
            .Include(d => d.ModifiedBy)
            .ToListAsync();
    }

    public async Task<Department?> GetDepartmentByIdAsync(int id)
    {
        return await _context.Departments
            .Include(d => d.CreatedBy)
            .Include(d => d.ModifiedBy)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Department> AddDepartmentAsync(Department department)
    {
        department.CreatedOn = DateTime.UtcNow;
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
        return department;
    }

    public async Task<Department?> UpdateDepartmentAsync(Department department)
    {
        var existing = await _context.Departments.FindAsync(department.Id);
        if (existing == null) return null;

        existing.Name = department.Name;
        existing.Code = department.Code;
        existing.ModifiedOn = DateTime.UtcNow;
        existing.ModifiedById = department.ModifiedById;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<Department?> DeleteDepartmentAsync(int id)
    {
        var entity = await _context.Departments.FindAsync(id);
        if (entity == null) return null;

        _context.Departments.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}