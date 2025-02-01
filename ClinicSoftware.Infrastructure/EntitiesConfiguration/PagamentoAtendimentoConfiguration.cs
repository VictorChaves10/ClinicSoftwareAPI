using ClinicSoftware.Domain.Entities.Financeiro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicSoftware.Infrastructure.EntitiesConfiguration
{
    public class PagamentoAtendimentoConfiguration : IEntityTypeConfiguration<PagamentoAtendimento>
    {
        public void Configure(EntityTypeBuilder<PagamentoAtendimento> builder)
        {
            builder.ToTable("PagamentosAtendimentos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ValorPago)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(x => x.FormaPagamento)
                    .HasConversion<int>()
                    .IsRequired();

            builder.HasOne(x => x.Atendimento)
                   .WithMany(x => x.Pagamentos)
                   .HasForeignKey(x => x.IdAtendimento)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
