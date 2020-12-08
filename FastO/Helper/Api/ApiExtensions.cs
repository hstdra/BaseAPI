using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace FastO.Helper.Api
{
    public static class ApiExtensions
    {
        public static IServiceCollection AddApi(this IServiceCollection services, params Type[] types)
        {
            var assemblies = types.Select(type => type.GetTypeInfo().Assembly);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddHealthChecks();

            services
                .AddMvc(opt =>
                {
                    opt.Filters.Add<ExceptionFilter>();
                })
                .AddFluentValidation(cfg =>
                {
                    cfg.RegisterValidatorsFromAssemblies(assemblies);
                })
                .ConfigureApiBehaviorOptions(opt =>
                {
                    opt.SuppressModelStateInvalidFilter = true;
                });

            return services;
        }

        public static IApplicationBuilder UseApi(this IApplicationBuilder app, IConfiguration Configuration)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
            });

            return app;
        }
    }
}
