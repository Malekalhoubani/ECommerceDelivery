using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts;

public abstract class BaseDbContext : DbContext
{
    protected BaseDbContext(DbContextOptions options)
        : base(options)
    {
    }
}