
using Cross_Zero.Core.Context;
using Cross_Zero.Core.Repository;
using Cross_Zero.Infrastructure.Context;
using Cross_Zero.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cross_Zero.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesInfrastructure(this IServiceCollection services,
           IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("MySqlConnection")!;

            services.AddDbContext<IApplicationContextEF, ApplicationContextEF>(options =>
                options.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString),
                    options => options.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: System.TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null)
                ));

            services.AddScoped<IGameRepository,GameRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
                

            return services;
        }
    }
}
