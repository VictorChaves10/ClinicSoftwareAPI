using ClinicSoftware.Domain.Entities.Atendimentos;
using ClinicSoftware.Domain.Entities.Clientes;
using ClinicSoftware.Domain.Entities.Financeiro;
using ClinicSoftware.Domain.Entities.Funcionarios;
using ClinicSoftware.Domain.Entities.Procedimentos;
using Microsoft.EntityFrameworkCore;

namespace ClinicSoftware.Infrastructure.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Procedimento> Procedimentos { get; set; }
    public DbSet<Atendimento> Atendimentos { get; set; }
    public DbSet<AtendimentoProcedimento> AtendimentoProcedimentos { get; set; }
    public DbSet<PagamentoAtendimento> PagamentosAtendimentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
