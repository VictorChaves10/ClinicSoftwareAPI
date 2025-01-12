using ClinicSoftware.Domain.Entities.Funcionarios;
using ClinicSoftware.Domain.Entities.Procedimentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicSoftware.Infrastructure.EntitiesConfiguration
{
    public class ProcedimentoConfiguration : IEntityTypeConfiguration<Procedimento>
    {
        public void Configure(EntityTypeBuilder<Procedimento> entity)
        {

            entity.ToTable("Procedimentos");

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Nome)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(p => p.Descricao)
                  .HasMaxLength(250);

            entity.Property(p => p.Preco)
                  .IsRequired()
                  .HasColumnType("decimal(18,2)");


        }
    }
}
