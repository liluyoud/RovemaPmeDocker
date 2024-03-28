using Rovema.Shared.Entities;

namespace Rovema.Shared.Repositories;

public interface IRpaRepository
{
    Task<IEnumerable<Rpa>> GetAllAsync();
    Task<Rpa?> GetByIdAsync(Guid id);
}
