using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using test.Domain.Entities;

namespace test.Data.EntityTypeConfigurations
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.NumeroDocumento).HasMaxLength(20).IsRequired();
            builder.HasAlternateKey(p => p.NumeroDocumento);
            builder.Property(p => p.Nombre).HasMaxLength(255).IsRequired();
        }
    }
}
