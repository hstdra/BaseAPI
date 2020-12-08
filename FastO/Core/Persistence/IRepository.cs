namespace FastO.Core
{
    public interface IRepository<TEntity> : IQueryRepository<TEntity>, ICommandRepository<TEntity> where TEntity : Entity
    {
    }
}
