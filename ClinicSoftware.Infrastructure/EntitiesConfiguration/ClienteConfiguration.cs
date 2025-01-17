using ClinicSoftware.Domain.Entities.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicSoftware.Infrastructure.EntitiesConfiguration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> entity)
    {
        entity.ToTable("Clientes");

        entity.HasKey(c => c.Id);

        entity.Property(c => c.Nome).IsRequired().HasMaxLength(150);
        entity.Property(c => c.Email).HasMaxLength(100);
        entity.Property(c => c.Telefone).IsRequired().HasMaxLength(20);
        entity.Property(c => c.Endereco).HasMaxLength(250);
        entity.Property(c => c.CPF).HasMaxLength(11);
        entity.Property(c => c.DataNascimento);
    }
}
