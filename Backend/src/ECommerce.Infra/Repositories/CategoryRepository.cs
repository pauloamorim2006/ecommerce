using ECommerce.Core.Infra;
using ECommerce.Domain.Models;
using ECommerce.Domain.Repositories;
using ECommerce.Infra.Context;
using ECommerce.Infra.Context.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ECommerceDbContext _context;
        
        public CategoryRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(Category entity)
        {
            _context.Categories.Add(entity);
        }

        public async Task<bool> Exists(Guid id, string name)
        {
            return await _context.Categories.AsNoTracking().Where(x => x.Id != id && x.Name == name).FirstOrDefaultAsync() != null;
        }

        public async Task<List<Category>> FindAll()
        {
            return await _context.Categories.Include(x => x.Subcategories).AsNoTracking().ToListAsync();
        }

        public async Task<Category> FindById(Guid id)
        {
            return await _context.Categories.Include(x => x.Subcategories).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Remove(Guid id)
        {
            var register = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(register);
        }

        public void Update(Category entity)
        {
            _context.Categories.Update(entity);
        }
    }
}
