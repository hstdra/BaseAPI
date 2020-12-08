using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace FastO.Helper.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddPrebuiltSwagger(this IServiceCollection services, IConfiguration Configuration)
        {
            var options = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(options);

            var title = AppDomain.CurrentDomain.FriendlyName.Trim().Trim('_');
            var filePath = Path.Combine(AppContext.BaseDirectory, $"{title}.xml");

            if (string.IsNullOrWhiteSpace(options.Title))
            {
                options.Title = title;
            }

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc(options.VersionName, options);
                c.CustomSchemaIds(x => x.FullName);
                //c.IncludeXmlComments(filePath);
            });

            return services;
        }

        public static IApplicationBuilder UsePrebuiltSwagger(this IApplicationBuilder app, IConfiguration Configuration)
        {
            var options = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(options);

            if (string.IsNullOrWhiteSpace(options.Title))
            {
                options.Title = AppDomain.CurrentDomain.FriendlyName.Trim().Trim('_');
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{options.VersionName}/swagger.json", options.Title);
                c.RoutePrefix = options.RoutePrefix;
            });

            return app;
        }
    }
}
