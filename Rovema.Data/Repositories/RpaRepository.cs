using Microsoft.EntityFrameworkCore;
using Rovema.Data.Contexts;
using Rovema.Shared.Entities;
using Rovema.Shared.Repositories;

namespace Rovema.Data.Repositories;

public class RpaRepository : IRpaRepository
{
    private readonly RovemaContext _context;

    public RpaRepository(RovemaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Rpa>> GetAllAsync()
    {
        return await _context.Rpas.AsNoTracking().ToListAsync();
    }

    public async Task<Rpa?> GetByIdAsync(Guid id)
    {
        return await _context.Rpas.FindAsync(id);
    }
}
