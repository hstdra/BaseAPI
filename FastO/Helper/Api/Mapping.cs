using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace FastO.Helper.Api
{
    public static class Mapping
    {
        public static TTarget Map<TSource, TTarget>(this TSource source)
            where TSource : class
            where TTarget : class
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TTarget>());

            var mapper = new Mapper(config);

            return mapper.Map<TSource, TTarget>(source);
        }
    }

    public static class MappingExtensions
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

        public static TTarget Map<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TTarget>());
            var mapper = new Mapper(config);

            return mapper.Map<TSource, TTarget>(source);
        }
    }
}
