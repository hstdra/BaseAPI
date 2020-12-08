using FastO.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FastO.Infrastructure.Persistence.MysqlEfRepositories
{
    public class MysqlEfCommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : Entity
    {
        private readonly DbContext _dbContext;

        public MysqlEfCommandRepository(IServiceScopeFactory serviceScopeFactory)
        {
            var scope = serviceScopeFactory.CreateScope();

            _dbContext = (DbContext)scope.ServiceProvider.GetRequiredService(MysqlOptions.DbContextType);
        }

        public async Task<Guid> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var newEntity = await _dbContext.Set<TEntity>().AddAsync(entity);

            return newEntity.Entity.Id;
        }

        public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
    }
}
