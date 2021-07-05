using ECommerce.Core.Infra;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Domain.Repositories
{
    public interface IBrandRepository : IRepository
    {
        void Add(Brand entity);

        void Update(Brand entity);

        Task Remove(Guid id);

        Task<Brand> FindById(Guid id);
        
        Task<List<Brand>> FindAll();

        Task<bool> Exists(Guid id, string name);
    }
}