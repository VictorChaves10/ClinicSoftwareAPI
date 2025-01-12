using ClinicSoftware.Domain.Entities.Cliente;
using ClinicSoftware.Domain.Entities.Funcionarios;
using ClinicSoftware.Domain.Entities.Procedimentos;
using Microsoft.EntityFrameworkCore;

namespace ClinicSoftware.Infrastructure.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Procedimento> Procedimentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
