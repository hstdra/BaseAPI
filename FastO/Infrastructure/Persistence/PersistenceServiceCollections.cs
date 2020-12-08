using Microsoft.Extensions.DependencyInjection;
using System;

namespace FastO.Infrastructure.Persistence
{
    public static class PersistenceServiceCollections
    {
        public static void AddPersistence(this IServiceCollection services, Action<PersistenceOptions> setupAction)
        {
            var options = new PersistenceOptions();
            setupAction(options);
            options.AddServices(services);
        }
    }
}
