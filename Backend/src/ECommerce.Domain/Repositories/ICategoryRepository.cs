using ECommerce.Core.Infra;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Domain.Repositories
{
    public interface ICategoryRepository : IRepository
    {
        void Add(Category entity);

        void Update(Category entity);

        Task Remove(Guid id);

        Task<Category> FindById(Guid id);
        
        Task<List<Category>> FindAll();

        Task<bool> Exists(Guid id, string name);
    }
}