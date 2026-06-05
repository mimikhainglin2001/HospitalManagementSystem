using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models;

public class Department : UserCreateActivity
{
    public int Id { get; set; }

    [Required]
    public string Code { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;
}