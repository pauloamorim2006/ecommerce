using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infra.Mappings
{
    public class SubcategoryMapping : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            builder.ToTable("Subcategories");

            builder.HasKey(p => p.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
        }
    }
}
