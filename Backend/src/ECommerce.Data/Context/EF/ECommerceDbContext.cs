using ECommerce.Core.Infra;
using ECommerce.Domain.Models;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ECommerce.Infra.Context.EF
{
    public class ECommerceDbContext : DbContext, IUnitOfWork
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }        
        public DbSet<Category> Categories { get; set; }

        public DbSet<Subcategory> Subcategories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ECommerceDbContext).Assembly);

            modelBuilder.Ignore<ValidationResult>();

            base.OnModelCreating(modelBuilder);
        }
    }
}