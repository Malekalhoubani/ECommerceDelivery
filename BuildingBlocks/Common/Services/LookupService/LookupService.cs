]using DataAccess.Repositories.LookupRepository;
using SharedKernel.Entities;

namespace Common.Services.LookupService
{
    public class LookupService<T> : ILookupService<T>
        where T : LookupBase
    {
        private readonly ILookupRepository<T> _repository;

        public LookupService(ILookupRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<T>> GetActiveAsync(CancellationToken cancellationToken = default)
        {
            return await _repository.GetActiveAsync(cancellationToken);
        }

        public async Task<T?> GetByCodeAsync(string code,CancellationToken cancellationToken = default)
        {
            return await _repository.GetByCodeAsync(
                code,
                cancellationToken);
        }

        public async Task<T?> GetByIdAsync(int id,CancellationToken cancellationToken = default)
        {
            return await _repository.GetByIdAsync(
                id,
                cancellationToken);
        }
    }
}