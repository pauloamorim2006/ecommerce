using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infra.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(p => p.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
            builder.Property(c => c.Image)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");         
        }
    }
}
