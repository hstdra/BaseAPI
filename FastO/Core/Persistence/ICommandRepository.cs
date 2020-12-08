using System;
using System.Threading;
using System.Threading.Tasks;

namespace FastO.Core
{
    public interface ICommandRepository<TEntity> where TEntity : Entity
    {
        Task<Guid> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
