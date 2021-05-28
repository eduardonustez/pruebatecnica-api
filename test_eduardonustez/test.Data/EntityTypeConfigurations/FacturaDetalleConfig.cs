using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using test.Domain.Entities;

namespace test.Data.EntityTypeConfigurations
{
    public class FacturaDetalleConfig : IEntityTypeConfiguration<FacturaDetalle>
    {
        public void Configure(EntityTypeBuilder<FacturaDetalle> builder)
        {
            builder.ToTable("FacturaDetalle");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasOne(p => p.Factura).WithMany(q => q.Items);
            builder.HasOne(p => p.Producto).WithMany();
        }
    }
}
