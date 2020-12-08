using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace FastO.Helper.Mapper
{
    public static class MapperExtensions
    {
        public static void AddMapper(this IServiceCollection services, Profile profile)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(profile);
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
