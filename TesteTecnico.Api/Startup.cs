using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TesteTecnico.Api.Configurations;
using TesteTecnico.Infra.Data;

namespace TesteTecnico.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseConfiguration(Configuration);
            services.AddAuthenticationConfiguration(Configuration);
            services.AddAutoMapperConfiguration();
            services.AddIoC();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // run migrations
            using (IServiceScope serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                ApplicationDbContext context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.SetCommandTimeout(300);
                context.Database.Migrate();
            }

            MasterUserConfig.ConfigAuthorizationRolesAndMasterUser(app).ConfigureAwait(false).GetAwaiter().GetResult();
            SeederData.SeedInitialData(app);
        }
    }
}
