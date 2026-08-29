using BuildingBlocks.SharedKernel.Entities;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories;

public class GenericRepository<T> : IRepository<T>
    where T : BaseEntity
{
    protected readonly BaseDbContext Context;
    protected readonly DbSet<T> DbSet;

    public GenericRepository(BaseDbContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await DbSet
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IReadOnlyList<T>> FindAsync(
        Expression<Func<T, bool>> predicate)
    {
        return await DbSet
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();
    }

    public async Task<bool> AnyAsync(
        Expression<Func<T, bool>> predicate)
    {
        return await DbSet.AnyAsync(predicate);
    }

    public async Task<int> CountAsync(
        Expression<Func<T, bool>>? predicate = null)
    {
        return predicate == null
            ? await DbSet.CountAsync()
            : await DbSet.CountAsync(predicate);
    }

    public async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        DbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        DbSet.Remove(entity);
    }
    public async Task<bool> ExistsAsync(int id)
    {
        return await DbSet.AnyAsync(x => x.Id == id);
    }
}