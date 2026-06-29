using HospitalManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
namespace HospitalManagementSystem.Services
{
    public class NumberSeriesGenerationService
    {
        private readonly ApplicationDbContext _context;
        public NumberSeriesGenerationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<String> GenerateEmployeeNumberAsync()
    {
        var lastemployee = await _context.Employees
        .OrderByDescending(p=>p.Id)
        .FirstOrDefaultAsync();

        int nextnumber = 1;
        if(lastemployee != null && !string.IsNullOrEmpty(lastemployee.EmployeeNo))
        {
            //EMP0001
            var lastnumberpart = lastemployee.EmployeeNo.Substring(3);
            if(int.TryParse(lastnumberpart, out int lastnumeric))
            {
                nextnumber = lastnumeric + 1;
            }
        }
        return $"EMP{nextnumber.ToString("D4")}";
    }

    public async Task<String> GeneratePatientNumberAsync()
    {
        var lastpatient = await _context.Patients
        .OrderByDescending(p=>p.Id)
        .FirstOrDefaultAsync();

        int nextnumber = 1;
        if(lastpatient != null && !string.IsNullOrEmpty(lastpatient.PatientNo))
        {
            //PT0001
            var lastnumberpart = lastpatient.PatientNo.Substring(2);
            if(int.TryParse(lastnumberpart, out int lastnumeric))
            {
                nextnumber = lastnumeric + 1;
            }
        }
        return $"PT{nextnumber.ToString("D4")}";
    }
    public async Task<String> GenerateAppointmentNumberAsync()
    {
        var lastappointment = await _context.Appointments
        .OrderByDescending(p=>p.Id)
        .FirstOrDefaultAsync();

        int nextnumber = 1;
        if(lastappointment != null && !string.IsNullOrEmpty(lastappointment.AppointmentNo))
        {
            //EMP0001
            var lastnumberpart = lastappointment.AppointmentNo.Substring(3);
            if(int.TryParse(lastnumberpart, out int lastnumeric))
            {
                nextnumber = lastnumeric + 1;
            }
        }
        return $"App{nextnumber.ToString("D4")}";
    }
    }
}