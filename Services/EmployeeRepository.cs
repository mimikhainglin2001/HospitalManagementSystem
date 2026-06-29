namespace HospitalManagementSystem.Services;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;
    private readonly NumberSeriesGenerationService _numberseries;

    public EmployeeRepository(ApplicationDbContext context, NumberSeriesGenerationService numberseries)
    {
        _context = context;
        _numberseries = numberseries;
    }

    public async Task<List<Employee>> GetEmployeesAsync()
    {
        return await _context.Employees
            .Include(e => e.Department)
            .Include(e => e.Role)
            .Include(e => e.Designation)
            .Include(e => e.Specialist)
            .Include(e => e.Gender)
            .Include(e => e.MaritalStatus)
            .Include(e => e.BloodGroup)
            .Include(e => e.Status)
            .Include(e => e.CreatedBy)
            .Include(e => e.ModifiedBy)
            .ToListAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        return await _context.Employees
            .Include(e => e.Department)
            .Include(e => e.Role)
            .Include(e => e.Designation)
            .Include(e => e.Specialist)
            .Include(e => e.Gender)
            .Include(e => e.MaritalStatus)
            .Include(e => e.BloodGroup)
            .Include(e => e.Status)
            .Include(e => e.CreatedBy)
            .Include(e => e.ModifiedBy)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Employee> AddEmployeeAsync(Employee employee)
    {
        var activeStatus = await _context.SystemCodeDetails
        .Include(s => s.SystemCode)
        .FirstOrDefaultAsync(s => s.SystemCode.Code == "EmployeesStatus" && s.Code == "Active");
        employee.StatusId = activeStatus.Id;
        employee.EmployeeNo = await _numberseries.GenerateEmployeeNumberAsync();
        employee.CreatedOn = DateTime.UtcNow;
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee?> UpdateEmployeeAsync(Employee employee)
    {
        var existing = await _context.Employees.FindAsync(employee.Id);
        if (existing == null) return null;

        existing.EmployeeNo = employee.EmployeeNo;
        existing.IdNumber = employee.IdNumber;
        existing.FirstName = employee.FirstName;
        existing.MiddleName = employee.MiddleName;
        existing.LastName = employee.LastName;
        existing.EmailAddress = employee.EmailAddress;
        existing.PhoneNumber = employee.PhoneNumber;
        existing.DateOfBirth = employee.DateOfBirth;
        existing.DateOfJoining = employee.DateOfJoining;
        existing.RoleId = employee.RoleId;
        existing.DesignationId = employee.DesignationId;
        existing.DepartmentId = employee.DepartmentId;
        existing.SpecialistId = employee.SpecialistId;
        existing.FatherName = employee.FatherName;
        existing.MotherName = employee.MotherName;
        existing.GenderId = employee.GenderId;
        existing.MaritalStatusId = employee.MaritalStatusId;
        existing.BloodGroupId = employee.BloodGroupId;
        existing.StatusId = employee.StatusId;
        existing.ModifiedOn = DateTime.UtcNow;
        existing.ModifiedById = employee.ModifiedById;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<Employee?> DeleteEmployeeAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null) return null;

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    
}