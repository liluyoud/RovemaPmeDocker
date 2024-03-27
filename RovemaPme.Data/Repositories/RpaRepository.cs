using Microsoft.EntityFrameworkCore;
using RovemaPme.Data.Contexts;
using RovemaPme.Shared.Dtos;
using RovemaPme.Shared.Repositories;

namespace RovemaPme.Data.Repositories;

public class RpaRepository<T> : IRpaRepository<T>
{
    private readonly RovemaPmeContext _context;

    public RpaRepository(RovemaPmeContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RpaDto>> GetAllAsync()
    {
        return await _context.Rpas.Select(r => new RpaDto(r.Id, r.Name, r.Type, r.TimeZone, r.TimeToFail, r.Active)).ToListAsync();
    }

    public async Task<RpaDto?> GetByIdAsync(T id)
    {
        var rpa = await _context.Rpas.FindAsync(id);
        if (rpa != null) 
            return new RpaDto(rpa.Id, rpa.Name, rpa.Type, rpa.TimeZone, rpa.TimeToFail, rpa.Active);
        return null;
    }
}
