namespace HospitalManagementSystem.Services;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
public class CountryRepository : ICountryRepository
{
    private readonly ApplicationDbContext _context;

    public CountryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Country>> GetCountriesAsync()
    {
        return await _context.Countries
            .Include(c => c.CreatedBy)
            .Include(c => c.ModifiedBy)
            .ToListAsync();
    }

    public async Task<Country?> GetCountryByIdAsync(int id)
    {
        return await _context.Countries
            .Include(c => c.CreatedBy)
            .Include(c => c.ModifiedBy)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Country> AddCountryAsync(Country country)
    {
        country.CreatedOn = DateTime.UtcNow;
        await _context.Countries.AddAsync(country);
        await _context.SaveChangesAsync();
        return country;
    }

    public async Task<Country?> UpdateCountryAsync(Country country)
    {
        var existing = await _context.Countries.FindAsync(country.Id);

        if (existing == null) return null;

        existing.Name = country.Name;
        existing.Code = country.Code;
        existing.ModifiedOn = DateTime.UtcNow;
        existing.ModifiedById = country.ModifiedById;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<Country?> DeleteCountryAsync(int id)
    {
        var entity = await _context.Countries.FindAsync(id);

        if (entity == null) return null;

        _context.Countries.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}