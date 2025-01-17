using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicSoftware.Domain.Entities.Financeiro
{
    public class DescontoConfiguration : IEntityTypeConfiguration<Desconto>
    {
        public void Configure(EntityTypeBuilder<Desconto> builder)
        {
            builder.ToTable("Descontos");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Valor)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();
        }
    }
}
