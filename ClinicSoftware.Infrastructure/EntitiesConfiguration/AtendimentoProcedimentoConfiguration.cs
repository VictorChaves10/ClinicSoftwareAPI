using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicSoftware.Domain.Entities.Atendimentos
{
    public class AtendimentoProcedimentoConfiguration : IEntityTypeConfiguration<AtendimentoProcedimento>
    {
        public void Configure(EntityTypeBuilder<AtendimentoProcedimento> builder)
        {
            builder.ToTable("AtendimentosProcedimentos");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Quantidade)
                   .IsRequired();

            builder.Property(a => a.Subtotal)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.HasOne(a => a.Atendimento)
                   .WithMany(a => a.Procedimentos)
                   .HasForeignKey(d => d.IdAtendimento)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Procedimento)
                   .WithMany()
                   .HasForeignKey(d => d.IdProcedimento)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();

            builder.HasOne(a => a.Funcionario)
                   .WithMany()
                   .HasForeignKey(d => d.IdFuncionario)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();
        }
    }
}
