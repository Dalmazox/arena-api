using Arena.Application.Services;
using Arena.Domain.Interfaces.Services;
using Arena.Domain.Interfaces.UnitOfWork;
using Arena.Infra.Data.Context;
using Arena.Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arena.Infra.IoC
{
    public static class Injector
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .RegisterDbContext(configuration)
                .AddServices();

            return services;
        }

        private static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<ArenaContext>(options => options.UseNpgsql(connectionString));

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ITeamService, TeamService>();

            return services;
        }
    }
}
