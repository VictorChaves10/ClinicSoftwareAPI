using ClinicSoftware.Application.Interfaces;
using ClinicSoftware.Application.Mappings;
using ClinicSoftware.Application.Services;
using ClinicSoftware.Domain.Interfaces;
using ClinicSoftware.Infrastructure.Context;
using ClinicSoftware.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicSoftware.CrossCutting.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();

            services.AddAutoMapper(typeof(DomainToDtoMapping));

            return services;
        }
    }
}
