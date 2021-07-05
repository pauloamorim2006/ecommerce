using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infra.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");            
            builder.Property(c => c.Color)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            builder.Property(c => c.Price)
                .IsRequired();
            builder.Property(c => c.Maker)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            builder.Property(c => c.Model)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            builder.Property(c => c.Certification)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            builder.Property(c => c.TypeMaterial)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            builder.Property(c => c.Quantity)
                .IsRequired();
            builder.Property(c => c.Size)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            builder.Property(c => c.Details);
            builder.Property(c => c.Rating)
                .IsRequired();
            builder.Property(c => c.FreeShipping)
                .IsRequired();
    }
    }
}
