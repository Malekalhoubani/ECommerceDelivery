using DataAccess.Models;
using DataAccess.Specifications;
using System.Linq.Expressions;

namespace DataAccess.Repositories.GenericRepository;

public interface IRepository<T>
{
    Task<T?> GetByIdAsync(int id,CancellationToken cancellationToken = default);

    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate,CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate,CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null,CancellationToken cancellationToken = default);

    Task AddAsync(T entity,CancellationToken cancellationToken = default);

    void Update(T entity);

    void Delete(T entity);

    Task<bool> ExistsAsync(int id,CancellationToken cancellationToken = default);

    Task AddRangeAsync(IEnumerable<T> entities,CancellationToken cancellationToken = default);

    void DeleteRange(IEnumerable<T> entities);

    Task<PagedResult<T>> GetPagedAsync(int pageNumber,int pageSize,CancellationToken cancellationToken = default);

    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification,CancellationToken cancellationToken = default);

    Task<T?> FirstOrDefaultAsync(ISpecification<T> specification,CancellationToken cancellationToken = default);

    Task<int> CountAsync(ISpecification<T> specification,CancellationToken cancellationToken = default);
}