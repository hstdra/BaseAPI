using FastO.Core.DDD;
using FastO.Core.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FastO.Infrastructure.Persistence.MysqlEfRepositories
{
    public class MysqlEfRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DbContext _dbContext;

        public MysqlEfRepository(IHttpContextAccessor accessor)
        {
            _dbContext = (DbContext)accessor.HttpContext.RequestServices.GetRequiredService(MysqlOptions.DbContextType);
        }

        public async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetOneAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task<Guid> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TEntity>().Update(entity);

            return entity.Id;
        }
    }
}
