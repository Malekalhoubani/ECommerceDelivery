using DataAccess.Repositories.GenericRepository;
using SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.LookupRepository
{
     public interface ILookupRepository<T> : IRepository<T> where T : LookupBase
    {
        Task<IReadOnlyList<T>> GetActiveAsync(CancellationToken cancellationToken = default);
        Task<T> GetByCodeAsync(string code, CancellationToken cancellationToken = default);
    }
}
