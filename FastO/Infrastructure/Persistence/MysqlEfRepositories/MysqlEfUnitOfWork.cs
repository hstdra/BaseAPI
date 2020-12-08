using FastO.Core.DDD;
using FastO.Core.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FastO.Infrastructure.Persistence.MysqlEfRepositories
{
    public class MysqlEfUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private readonly IServiceProvider _serviceProvider;
        private bool mustRollBack;

        public MysqlEfUnitOfWork(IHttpContextAccessor accessor)
        {
            _serviceProvider = accessor.HttpContext.RequestServices;
            _dbContext = (DbContext)_serviceProvider.GetRequiredService(MysqlOptions.DbContextType);
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity
        {
            return (IRepository<TEntity>)_serviceProvider.GetRequiredService(typeof(IRepository<TEntity>));
        }

        public void RollBack()
        {
            mustRollBack = true;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (!mustRollBack)
            {
                Commit();
            }
        }
    }
}
