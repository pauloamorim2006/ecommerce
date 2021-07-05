using ECommerce.Domain.Models;
using ECommerce.Domain.Repositories;
using ECommerce.Infra.Context.Mongo;
using ECommerce.Infra.Context.Mongo.Configuration;
using ECommerce.Infra.Utils;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Infra.Repositories
{
    public class BrandCollectionRepository : IBrandCollectionRepository
    {
        private readonly IMongoCollection<Product> _products;

        public BrandCollectionRepository(IMongoConnection connection)
        {
            _products = connection.GetCollection<Product>(MongoCollections.Products);
        }

        public async Task<List<Brand>> Find(Guid subcategoryId)
        {
            var all = await _products.FindAsync(Builders<Product>.Filter.Empty);
            var products = all.ToList().Where(x => x.SubcategoryId == subcategoryId);
            var brands = products.Select(x => new Brand(x.BrandId, x.Brand.Name)).Distinct().OrderBy(x => x.Name).ToList();
            return brands;
        }
    }
}
