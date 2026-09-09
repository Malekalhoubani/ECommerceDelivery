using BuildingBlocks.SharedKernel.Entities;
using DataAccess.Contexts;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories.GenericRepository;

public class GenericRepository<T> :
    IRepository<T>,
    IReadRepository<T>
    where T : BaseEntity
{
    protected readonly BaseDbContext Context;
    protected readonly DbSet<T> DbSet;

    public GenericRepository(BaseDbContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync(
            new object[] { id },
            cancellationToken);
    }

    async Task<T?> IReadRepository<T>.GetByIdAsync(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await DbSet
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    async Task<IReadOnlyList<T>> IReadRepository<T>.GetAllAsync()
    {
        return await GetAllAsync();
    }

    public async Task<IReadOnlyList<T>> FindAsync(
        Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await DbSet
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync(cancellationToken);
    }

    async Task<IReadOnlyList<T>> IReadRepository<T>.FindAsync(
        Expression<Func<T, bool>> predicate)
    {
        return await FindAsync(predicate);
    }

    public async Task<bool> AnyAsync(
        Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await DbSet.AnyAsync(
            predicate,
            cancellationToken);
    }

    async Task<bool> IReadRepository<T>.AnyAsync(
        Expression<Func<T, bool>> predicate)
    {
        return await AnyAsync(predicate);
    }

    public async Task<int> CountAsync(
        Expression<Func<T, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        return predicate == null
            ? await DbSet.CountAsync(cancellationToken)
            : await DbSet.CountAsync(
                predicate,
                cancellationToken);
    }

    async Task<int> IReadRepository<T>.CountAsync(
        Expression<Func<T, bool>>? predicate)
    {
        return await CountAsync(predicate);
    }

    public async Task AddAsync(
        T entity,
        CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(
            entity,
            cancellationToken);
    }

    public void Update(T entity)
    {
        DbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        DbSet.Remove(entity);
    }

    public async Task<bool> ExistsAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return await DbSet.AnyAsync(
            x => x.Id == id,
            cancellationToken);
    }

    public async Task AddRangeAsync(
        IEnumerable<T> entities,
        CancellationToken cancellationToken = default)
    {
        await DbSet.AddRangeAsync(
            entities,
            cancellationToken);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        DbSet.RemoveRange(entities);
    }

    public async Task<PagedResult<T>> GetPagedAsync(
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        pageNumber = pageNumber <= 0 ? 1 : pageNumber;
        pageSize = pageSize <= 0 ? 10 : pageSize;

        var totalCount = await DbSet
            .CountAsync(cancellationToken);

        var items = await DbSet
            .AsNoTracking()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<T>
        {
            Items = items,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }

    async Task<PagedResult<T>> IReadRepository<T>.GetPagedAsync(
        int pageNumber,
        int pageSize)
    {
        return await GetPagedAsync(pageNumber, pageSize);
    }

    public async Task<IReadOnlyList<T>> ListAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification)
            .ToListAsync(cancellationToken);
    }

    public async Task<T?> FirstOrDefaultAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<int> CountAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification)
            .CountAsync(cancellationToken);
    }

    private IQueryable<T> ApplySpecification(
        ISpecification<T> specification)
    {
        return SpecificationEvaluator<T>.GetQuery(
            DbSet.AsQueryable(),
            specification);
    }
}