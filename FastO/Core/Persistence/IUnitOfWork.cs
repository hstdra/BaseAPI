using FastO.Core.DDD;
using System;
using System.Threading.Tasks;

namespace FastO.Core.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity;

        void Commit();

        void RollBack();
    }
}
