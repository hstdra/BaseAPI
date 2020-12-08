using BaseAPI.Extensions;
using FastO.Helper.Api;
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
            services.AddHttpContextAccessor();
            services.AddControllers();

            services.AddApi(typeof(Startup));
            services.AddCQRS(typeof(Startup));
            services.AddMapper(new AppProfile());
            services.AddPrebuiltSwagger(Configuration);
            
            services.AddPersistence(o =>
            {
                o.UseMysqlEntityFramework<AppDbContext>(services, Configuration.GetConnectionString("DataDatabase"));
            });
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
            app.UseApi(Configuration);
        }
    }
}
