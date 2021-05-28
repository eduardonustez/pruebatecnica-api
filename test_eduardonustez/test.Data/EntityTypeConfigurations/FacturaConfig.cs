using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using test.Domain.Entities;

namespace test.Data.EntityTypeConfigurations
{
    public class FacturaConfig : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable("Facturas");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.NumeroFactura).IsRequired();
            builder.HasAlternateKey(p => p.NumeroFactura);
            builder.HasOne(p => p.Cliente).WithMany(q => q.Facturas);
        }
    }
}
