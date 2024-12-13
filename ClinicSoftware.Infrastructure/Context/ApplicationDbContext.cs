using ClinicSoftware.Domain.Entities.Cliente;
using ClinicSoftware.Domain.Entities.Pessoas;
using Microsoft.EntityFrameworkCore;

namespace ClinicSoftware.Infrastructure.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<PessoaFisica> PessoasFisica { get; set; }
    public DbSet<PessoaJuridica> PessoasJuridica { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
