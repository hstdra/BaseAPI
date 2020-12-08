using FastO.Helper.Swagger;
using FastO.Infrastructure.CQRS;
using FastO.Infrastructure.Persistence;
using FastO.Infrastructure.Persistence.MysqlEfRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BaseAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCQRS(typeof(Startup));

            services.AddPersistence(o =>
            {
                o.UseMysqlEntityFramework<AppContext>(services, Configuration.GetConnectionString("DataDatabase"));
            });

            services.AddPrebuiltSwagger(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UsePrebuiltSwagger(Configuration);
        }
    }
}
