using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Domain.Services
{
    public interface ISubcategoryService
    {
        Task<Subcategory> FindById(Guid id);
        Task<List<Subcategory>> FindAll();
        Task<bool> Add(Subcategory register);
        Task<bool> Update(Subcategory register);
        Task<bool> Remove(Guid id);
    }
}
