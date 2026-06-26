using HospitalManagementSystem.Data;
using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Services
{
    public class SystemCodeDetailsRepository : ISystemCodeDetailsRepository
{
    private readonly ApplicationDbContext _context;

    public SystemCodeDetailsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SystemCodeDetail>> GetSystemCodeDetailsAsync()
    {
        return await _context.SystemCodeDetails
            .Include(x => x.SystemCode)
            .Include(x => x.CreatedBy)
            .Include(x => x.ModifiedBy)
            .ToListAsync();
    }
     public async Task<List<SystemCodeDetail>> GetSystemCodeDetailsByCodeAsync(string code)
    {
        return await _context.SystemCodeDetails
            .Include(x => x.SystemCode)
            .Include(x => x.CreatedBy)
            .Include(x => x.ModifiedBy)
            .Where(x => x.SystemCode.Code == code)
            .ToListAsync();
    }

    public async Task<SystemCodeDetail?> GetSystemCodeDetailByIdAsync(int id)
    {
        return await _context.SystemCodeDetails
            .Include(x => x.SystemCode)
            .Include(x => x.CreatedBy)
            .Include(x => x.ModifiedBy)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<SystemCodeDetail> AddSystemCodeDetailAsync(SystemCodeDetail entity)
    {
        entity.CreatedOn = DateTime.UtcNow;
        await _context.SystemCodeDetails.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<SystemCodeDetail?> UpdateSystemCodeDetailAsync(SystemCodeDetail entity)
    {
        var existing = await _context.SystemCodeDetails.FindAsync(entity.Id);
        if (existing == null) return null;

        existing.Code = entity.Code;
        existing.Description = entity.Description;
        existing.SystemCodeId = entity.SystemCodeId;
        existing.OrderNo = entity.OrderNo;
        existing.ModifiedById = entity.ModifiedById;
        existing.ModifiedOn = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<SystemCodeDetail?> DeleteSystemCodeDetailAsync(int id)
    {
        var entity = await _context.SystemCodeDetails.FindAsync(id);
        if (entity == null) return null;

        _context.SystemCodeDetails.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
}