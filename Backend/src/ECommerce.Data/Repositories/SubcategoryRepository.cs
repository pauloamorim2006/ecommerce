using ECommerce.Core.Infra;
using ECommerce.Domain.Models;
using ECommerce.Domain.Repositories;
using ECommerce.Infra.Context.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Infra.Repositories
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly ECommerceDbContext _context;

        public SubcategoryRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(Subcategory entity)
        {
            _context.Subcategories.Add(entity);
        }

        public async Task<bool> Exists(Guid id, string name)
        {
            return await _context
                .Subcategories
                .AsNoTracking()
                .Where(x => x.Id != id && x.Name == name)
                .FirstOrDefaultAsync() != null;
        }

        public async Task<List<Subcategory>> FindAll()
        {
            return await _context.Subcategories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Subcategory> FindById(Guid id)
        {
            return await _context.Subcategories.FindAsync(id);
        }

        public async Task Remove(Guid id)
        {
            var register = await _context.Subcategories.FindAsync(id);
            _context.Subcategories.Remove(register);
        }

        public void Update(Subcategory entity)
        {
            _context.Subcategories.Update(entity);
        }
    }
}
