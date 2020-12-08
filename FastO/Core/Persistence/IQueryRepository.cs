using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FastO.Core
{
    public interface IQueryRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetOneAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
