using Microsoft.Extensions.DependencyInjection;
using TesteTecnico.Application.Interfaces;
using TesteTecnico.Application.Services;
using TesteTecnico.Domain.Core.Interfaces;
using TesteTecnico.Domain.Core.Services;
using TesteTecnico.Domain.Services.Services;
using TesteTecnico.Infra.Data;

namespace TesteTecnico.Api.Configurations
{
    public static class IoCConfig
    {
        public static void AddIoC(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IUserApplicationService, UserApplicationService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
