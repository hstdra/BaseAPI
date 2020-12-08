using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FastO.Infrastructure.Persistence.MysqlEfRepositories
{
    public static class PersistenceOptionsExtensions
    {
        public static PersistenceOptions UseMysqlEntityFramework<TContext>
            (this PersistenceOptions options, IServiceCollection services, string connectionString)
            where TContext : DbContext
        {
            services.AddDbContext<TContext>(options =>
            {
                options.UseMySQL(connectionString);
            });

            MysqlOptions.DbContextType = typeof(TContext);
            options.QueryType = typeof(MysqlEfQueryRepository<>);
            options.CommandType = typeof(MysqlEfCommandRepository<>);

            return options;
        }

        public static PersistenceOptions UseMysqlEntityFrameworkQuerySideOnly<TContext>
            (this PersistenceOptions options)
            where TContext : DbContext
        {
            MysqlOptions.DbContextType = typeof(TContext);
            options.QueryType = typeof(MysqlEfQueryRepository<>);

            return options;
        }

        public static PersistenceOptions UseMysqlEntityFrameworkCommandSideOnly<TContext>
            (this PersistenceOptions options)
            where TContext : DbContext
        {
            MysqlOptions.DbContextType = typeof(TContext);
            options.CommandType = typeof(MysqlEfCommandRepository<>);

            return options;
        }
    }
}
