using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Entities;
namespace Common.Services.LookupService
{
    public interface ILookupService <T> where T : LookupBase
    {
        Task<IReadOnlyList<T>> GetActiveAsync(CancellationToken cancellationToken = default);
        Task<T?> GetByCodeAsync(string code,CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(int id,CancellationToken cancellationToken = default);
    }
}
