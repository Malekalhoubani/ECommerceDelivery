using DataAccess.Contexts;
using DataAccess.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.LookupRepository
{
    public class LookupRepository<T> : GenericRepository<T>, ILookupRepository<T> where T : LookupBase
    {
        public LookupRepository(BaseDbContext context) : base(context)
        {
        }
        public async Task<IReadOnlyList<T>> GetActiveAsync(CancellationToken cancellationToken = default)
        {
           return await DbSet.AsNoTracking().Where(x=>x.IsActive).OrderBy(x=> x.DisplayOrder).ToListAsync(cancellationToken);
        }

        public async Task<T> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Code == code, cancellationToken);
        }

    }
}
