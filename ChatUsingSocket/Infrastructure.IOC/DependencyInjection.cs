using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddAutoMapper(typeof(DomainDTOMappingProfile));
            return services;
        }

    }
}
