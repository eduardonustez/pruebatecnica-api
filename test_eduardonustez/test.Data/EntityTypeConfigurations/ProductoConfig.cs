using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using test.Domain.Entities;

namespace test.Data.EntityTypeConfigurations
{
    public class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nombre).HasMaxLength(255).IsRequired();
        }
    }
}
