using BuildingBlocks.SharedKernel.Entities;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class QueryRepository<T> : IQueryRepository<T>
    where T : BaseEntity
{
    private readonly DbSet<T> _dbSet;

    public QueryRepository(BaseDbContext context)
    {
        _dbSet = context.Set<T>();
    }

    public IQueryable<T> Query()
    {
        return _dbSet.AsQueryable();
    }

    public IQueryable<T> QueryAsNoTracking()
    {
        return _dbSet.AsNoTracking();
    }
}