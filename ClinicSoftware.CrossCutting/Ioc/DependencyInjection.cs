using ClinicSoftware.Application.Factories;
using ClinicSoftware.Application.Interfaces;
using ClinicSoftware.Application.Mappings;
using ClinicSoftware.Application.Services;
using ClinicSoftware.Application.Validators;
using ClinicSoftware.Domain.Interfaces;
using ClinicSoftware.Infrastructure.Context;
using ClinicSoftware.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ClinicSoftware.CrossCutting.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddAutoMapper(typeof(DomainToDtoMapping));

            #region Application
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IProcedimentoService, ProcedimentoService>();
            services.AddScoped<IAtendimentoService, AtendimentoService>();
            services.AddScoped<IAtendimentoFactory, AtendimentoFactory>();
            #endregion

            #region Repository

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IProcedimentoRepository, ProcedimentoRepository>();
            services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
            services.AddScoped<IFinanceiroRepository, FinanceiroRepository>();

            #endregion

            #region Validators

            services.AddValidatorsFromAssemblyContaining<AtendimentoValidator>();


            #endregion

            return services;
        }
    }
}
