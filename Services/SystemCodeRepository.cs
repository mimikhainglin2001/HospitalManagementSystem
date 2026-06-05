using HospitalManagementSystem.Data;
using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Services
{
    public class SystemCodeRepository : ISystemCodeRepository
{
    private readonly ApplicationDbContext _context;

    public SystemCodeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SystemCode>> GetSystemCodesAsync()
    {
        return await _context.SystemCodes
            .Include(x => x.CreatedBy)
            .Include(x => x.ModifiedBy)
            .ToListAsync();
    }

    public async Task<SystemCode?> GetSystemCodeByIdAsync(int id)
    {
        return await _context.SystemCodes
            .Include(x => x.CreatedBy)
            .Include(x => x.ModifiedBy)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<SystemCodeDetail>> GetSystemCodeDetailsAsync(int systemCodeId)
    {
        return await _context.SystemCodeDetails
            .Include(x => x.SystemCode)
            .Include(x => x.CreatedBy)
            .Include(x => x.ModifiedBy)
            .Where(x => x.SystemCodeId == systemCodeId)
            .ToListAsync();
    }

    public async Task<SystemCode> AddSystemCodeAsync(SystemCode entity)
    {
        entity.CreatedOn = DateTime.UtcNow;
        await _context.SystemCodes.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<SystemCode?> UpdateSystemCodeAsync(SystemCode entity)
    {
        var existing = await _context.SystemCodes.FindAsync(entity.Id);
        if (existing == null) return null;

        existing.Code = entity.Code;
        existing.Description = entity.Description;
        existing.OrderNo = entity.OrderNo;
        existing.ModifiedById = entity.ModifiedById;
        existing.ModifiedOn = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<SystemCode?> DeleteSystemCodeAsync(int id)
    {
        var entity = await _context.SystemCodes.FindAsync(id);
        if (entity == null) return null;

        _context.SystemCodes.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
}