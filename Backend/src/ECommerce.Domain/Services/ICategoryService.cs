using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Domain.Services
{
    public interface ICategoryService
    {
        Task<Category> FindById(Guid id);
        Task<List<Category>> FindAll();
        Task<bool> Add(Category category);
        Task<bool> Update(Category category);
        Task<bool> Remove(Guid id);
    }
}
