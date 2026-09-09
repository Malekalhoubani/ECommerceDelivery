using BuildingBlocks.SharedKernel.Entities;

namespace DataAccess.Repositories.QueryRepository;

public interface IQueryRepository<T>
    where T : BaseEntity
{
    IQueryable<T> Query();

    IQueryable<T> QueryAsNoTracking();
}