using ECommerce.Domain.Filter;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Domain.Repositories
{
    public interface IProductCollectionRepository
    {
        Task<bool> Add(Product entity);

        Task<bool> Update(Product entity);

        Task<bool> Remove(Guid id);

        Task<(List<Product>, int)> Find(Guid subcategory, ProductFilter filter);

    }
}
