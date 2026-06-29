using HospitalManagementSystem.Models;
namespace HospitalManagementSystem.Interfaces
{
    public interface IEmployeeRepository
    {
    Task<List<Employee>> GetEmployeesAsync();
    Task<Employee?> GetEmployeeByIdAsync(int id);
    Task<Employee> AddEmployeeAsync(Employee employee);
    Task<Employee?> UpdateEmployeeAsync(Employee employee);
    Task<Employee?> DeleteEmployeeAsync(int id);
    }
}