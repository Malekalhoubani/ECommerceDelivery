using BuildingBlocks.SharedKernel.Entities;
using DataAccess.Models;
using System.Linq.Expressions;

namespace DataAccess.Repositories;

public interface IReadRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);

    Task<IReadOnlyList<T>> GetAllAsync();

    Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate);

    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    Task<PagedResult<T>> GetPagedAsync(int pageNumber,int pageSize);
}