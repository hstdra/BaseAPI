using FastO.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FastO.Infrastructure.Persistence
{
    public class PersistenceOptions
    {
        internal Type QueryType { get; set; }

        internal Type CommandType { get; set; }

        internal void AddServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(IQueryRepository<>), QueryType);
            services.AddScoped(typeof(ICommandRepository<>), CommandType);
        }
    }
}
