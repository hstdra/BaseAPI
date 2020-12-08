using FastO.Core.Persistence;
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
            MysqlOptions.DbContextType = typeof(TContext);
            
            services.AddDbContext<TContext>(options =>
            {
                options.UseMySQL(connectionString);
            });
            services.AddScoped(typeof(IRepository<>), typeof(MysqlEfRepository<>));
            services.AddScoped<IUnitOfWork, MysqlEfUnitOfWork>();

            return options;
        }
    }
}
