namespace HospitalManagementSystem.Services;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
public class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _context;

    public PatientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Patient>> GetPatientsAsync()
    {
        return await _context.Patients
            .Include(d => d.Gender)
            .Include(d => d.CreatedBy)
            .Include(d => d.ModifiedBy)
            .ToListAsync();
    }

    public async Task<Patient?> GetPatientByIdAsync(int id)
    {
        return await _context.Patients
            .Include(d => d.Gender)
            .Include(d => d.CreatedBy)
            .Include(d => d.ModifiedBy)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Patient> AddPatientAsync(Patient patient)
    {
        patient.CreatedOn = DateTime.UtcNow;
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
        return patient;
    }

    public async Task<Patient?> UpdatePatientAsync(Patient patient)
    {
        var existing = await _context.Patients.FindAsync(patient.Id);
        if (existing == null) return null;

        existing.FirstName = patient.FirstName;
        existing.MiddleName = patient.MiddleName;
        existing.LastName = patient.LastName;
        existing.DateOfBirth = patient.DateOfBirth;
        existing.GenderId = patient.GenderId;
        existing.Address = patient.Address;
        existing.PhoneNumber = patient.PhoneNumber;
        existing.EmailAddress = patient.EmailAddress;
        existing.BloodGroupId = patient.BloodGroupId;
        existing.GuardianPhoneNumber = patient.GuardianPhoneNumber;
        existing.GuardianName = patient.GuardianName;
        existing.Remarks = patient.Remarks;
        existing.Allergies = patient.Allergies;
        existing.ModifiedOn = DateTime.UtcNow;
        existing.ModifiedById = patient.ModifiedById;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<Patient?> DeletePatientAsync(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient == null) return null;

        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();
        return patient;
    }
}