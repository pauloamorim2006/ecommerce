using ECommerce.Domain.Filter;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Domain.Services
{
    public interface IBrandService
    {
        Task<List<Brand>> Find(Guid subcategoryId);

        Task<Brand> FindById(Guid id);
        Task<bool> Add(Brand register);
        Task<bool> Update(Brand register);
        Task<bool> Remove(Guid id);
    }
}
