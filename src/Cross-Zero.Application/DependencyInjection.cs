
using Cross_Zero.Application.Services;
using Cross_Zero.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Cross_Zero.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesApplication(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IUserService,UserService>();

            return services;
        }
    }
}
