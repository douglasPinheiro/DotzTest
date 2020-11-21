using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Api.Configurations
{
    public static class MasterUserConfig
    {
        public static async Task<IApplicationBuilder> ConfigAuthorizationRolesAndMasterUser(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var masterEmail = "master@admin.com";
                var masterPassword = "Admin@123";
                var cpf = "288.905.970-70";
                var fullName = "master user";
                var mobile = "11123456789";

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();

                var user = await userManager.FindByEmailAsync(masterEmail).ConfigureAwait(false);
                if (user == null)
                {
                    user = new User { UserName = masterEmail, Email = masterEmail, CPF = cpf, FullName = fullName, Mobile = mobile };
                    await userManager.CreateAsync(user, masterPassword).ConfigureAwait(false);
                }
            }

            return app;
        }
    }
}
