using DataAccess.Specifications;

namespace DataAccess.Models;

public interface IRepository<T>
{
    Task<T?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<T>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<T>> ListAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default);

    Task<T?> FirstOrDefaultAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default);

    Task<int> CountAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default);
}