using ECommerce.Core.Infra;
using ECommerce.Domain.Models;
using ECommerce.Domain.Repositories;
using ECommerce.Infra.Context;
using ECommerce.Infra.Context.EF;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDbContext _context;
       
        public ProductRepository(
            ECommerceDbContext context)
        {
            _context = context;            
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(Product entity)
        {
            _context.Products.Add(entity);
        }

        public void AddImage(Image entity)
        {
            _context.Images.Add(entity);
        }

        public async Task<bool> Exists(Guid id, string name)
        {
            return await _context.Products.AsNoTracking().Where(x => x.Id != id && x.Name == name).FirstOrDefaultAsync() != null;
        }

        public async Task<List<Product>> FindAll()
        {
            return await _context.Products
                .Include(x => x.Subcategory)
                .Include(x => x.Brand)
                .Include(x => x.Images)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product> FindById(Guid id)
        {
            return await _context.Products
                .Include(x => x.Subcategory)
                .Include(x => x.Brand)
                .Include(x => x.Images)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Remove(Guid id)
        {
            var register = await _context.Products.FindAsync(id);
            _context.Products.Remove(register);
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
        }
    }
}
