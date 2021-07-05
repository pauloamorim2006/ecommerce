using ECommerce.Domain.Filter;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Domain.Services
{
    public interface IProductService
    {
        Task<Product> FindById(Guid id);

        Task<List<Product>> FindAll();

        Task<(List<Product>, int)> Find(Guid subcategoryId, ProductFilter filter);

        Task<bool> Add(Product register);

        Task<bool> Update(Product register);

        Task<bool> Remove(Guid id);

        Task<bool> AddImage(Image entity);
    }
}
