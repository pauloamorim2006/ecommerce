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
    public class BrandRepository : IBrandRepository
    {
        private readonly ECommerceDbContext _context;
        
        public BrandRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(Brand entity)
        {
            _context.Brands.Add(entity);
        }

        public async Task<bool> Exists(Guid id, string name)
        {
            return await _context.Brands.AsNoTracking().Where(x => x.Id != id && x.Name == name).FirstOrDefaultAsync() != null;
        }

        public async Task<List<Brand>> FindAll()
        {
            return await _context.Brands.AsNoTracking().ToListAsync();
        }

        public async Task<Brand> FindById(Guid id)
        {
            return await _context.Brands.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Remove(Guid id)
        {
            var register = await _context.Brands.FindAsync(id);
            _context.Brands.Remove(register);
        }

        public void Update(Brand entity)
        {
            _context.Brands.Update(entity);
        }
    }
}
