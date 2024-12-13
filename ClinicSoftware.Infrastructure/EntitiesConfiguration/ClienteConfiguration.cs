using ClinicSoftware.Domain.Entities.Cliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSoftware.Infrastructure.EntitiesConfiguration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.DataCadastro);
            
            builder.HasOne(c => c.Pessoa)
                   .WithOne()
                   .HasForeignKey<Cliente>(c => c.PessoaId);
        }
    }
}
