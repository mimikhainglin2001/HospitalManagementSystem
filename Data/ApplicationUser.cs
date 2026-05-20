using System.ComponentModel.DataAnnotations;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace HospitalManagementSystem.Data;

public class ApplicationUser : IdentityUser
{
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

        [Display(Name = "First Name")]
    public string LastName { get; set; }

        [Display(Name = "Address")]
    public string Address { get; set; }

        [Display(Name = "Emergency Phone Number")]
    public string EmergencyPhoneNumber { get; set; }

        [Display(Name = "Date Of Birth")]
    public DateTime DateOfBirth { get; set; }

            [Display(Name = "Mother Name")]
    public string MotherName { get; set; }

                [Display(Name = "Father Name")]
    public string FatherName { get; set; }

                [Display(Name = "National Id Number")]
    public string NationalIdNumber { get; set; }

                [Display(Name = "Sex")]
    public int? GenderId { get; set;}
    public SystemCodeDetail Gender { get; set;}

                [Display(Name = "Blood Group")]
    public int? BloodGroupId { get; set;}
    public SystemCodeDetail BloodGroup { get; set;}

                [Display(Name = "Marital Status")]
    public int? MaritalStatusId { get; set;}
    public SystemCodeDetail MaritalStatus { get; set;}
}