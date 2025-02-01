using ClinicSoftware.Domain.Entities.Atendimentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicSoftware.Infrastructure.EntitiesConfiguration
{
    public class AtendimentoConfiguration : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder.ToTable("Atendimentos");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.DataHoraAtendimento)
                   .IsRequired()
                   .HasColumnType("datetime");

            builder.Property(a => a.DataRegistro)
                   .IsRequired()
                   .HasColumnType("datetime");

            builder.Property(a => a.Observacao)
                   .HasMaxLength(500);

            builder.HasOne(a => a.Cliente)
                   .WithMany()
                   .HasForeignKey(a => a.IdCliente)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();

            builder.HasMany(a => a.Procedimentos)
                   .WithOne(p => p.Atendimento)
                   .HasForeignKey(p => p.IdAtendimento)
                   .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasMany(a => a.Pagamentos)
                  .WithOne(p => p.Atendimento)
                  .HasForeignKey(p => p.IdAtendimento)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
