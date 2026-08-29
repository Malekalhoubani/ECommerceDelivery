using BuildingBlocks.SharedKernel.Entities;

namespace DataAccess.Repositories;

public interface IQueryRepository<T>
    where T : BaseEntity
{
    IQueryable<T> Query();

    IQueryable<T> QueryAsNoTracking();
}