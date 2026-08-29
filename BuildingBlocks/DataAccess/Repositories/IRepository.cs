using BuildingBlocks.SharedKernel.Entities;

namespace DataAccess.Repositories;

public interface IRepository<T> : IReadRepository<T>
    where T : BaseEntity
{
    Task AddAsync(T entity);

    Task AddRangeAsync(IEnumerable<T> entities);

    void Update(T entity);

    void Delete(T entity);

    void DeleteRange(IEnumerable<T> entities);

    Task<bool> ExistsAsync(int id);
}