using RovemaPme.Shared.Dtos;

namespace RovemaPme.Shared.Repositories;

public interface IRpaRepository<T>
{
    Task<IEnumerable<RpaDto>> GetAllAsync();
    Task<RpaDto?> GetByIdAsync(T id);
}
