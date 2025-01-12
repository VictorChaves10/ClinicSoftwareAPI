using ClinicSoftware.Domain.Entities.Funcionarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicSoftware.Infrastructure.EntitiesConfiguration
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> entity)
        {

            entity.ToTable("Funcionarios");

            entity.HasKey(f => f.Id);

            entity.Property(f => f.Nome)
                  .IsRequired()
                  .HasMaxLength(150);

            entity.Property(f => f.Email)
                  .HasMaxLength(100);

            entity.Property(f => f.Telefone)
                  .HasMaxLength(20);

            entity.Property(f => f.Endereco)
                  .HasMaxLength(250);

            entity.Property(f => f.CPF)
                  .HasMaxLength(11);

            entity.Property(f => f.DataNascimento)
                  .HasColumnType("date");

            entity.Property(f => f.SalarioBase)
                  .HasColumnType("decimal(18,2)");

        }
    }
}
