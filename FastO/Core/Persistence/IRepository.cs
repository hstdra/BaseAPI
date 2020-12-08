using FastO.Core.DDD;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FastO.Core.Persistence
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetOneAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Guid> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<Guid> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
