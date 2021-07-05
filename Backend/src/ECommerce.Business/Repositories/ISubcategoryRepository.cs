using ECommerce.Core.Infra;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Domain.Repositories
{
    public interface ISubcategoryRepository : IRepository
    {
        void Add(Subcategory entity);

        void Update(Subcategory entity);

        Task Remove(Guid id);

        Task<Subcategory> FindById(Guid id);

        Task<List<Subcategory>> FindAll();

        Task<bool> Exists(Guid id, string name);
    }
}
