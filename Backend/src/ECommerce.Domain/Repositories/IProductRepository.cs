using ECommerce.Core.Infra;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Domain.Repositories
{
    public interface IProductRepository : IRepository
    {
        void Add(Product entity);

        void Update(Product entity);

        Task Remove(Guid id);

        Task<Product> FindById(Guid id);

        Task<List<Product>> FindAll();

        Task<bool> Exists(Guid id, string name);

        void AddImage(Image entity);
    }
}
