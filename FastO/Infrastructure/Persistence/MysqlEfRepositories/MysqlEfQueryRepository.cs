using FastO.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FastO.Infrastructure.Persistence.MysqlEfRepositories
{
    public class MysqlEfQueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : Entity
    {
        private readonly DbContext _dbContext;

        public MysqlEfQueryRepository(IServiceScopeFactory serviceScopeFactory)
        {
            var scope = serviceScopeFactory.CreateScope();

            _dbContext = (DbContext)scope.ServiceProvider.GetRequiredService(MysqlOptions.DbContextType);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetOneAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
