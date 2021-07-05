using ECommerce.Domain.Filter;
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
    public class ProductCollectionRepository : IProductCollectionRepository
    {
        private readonly IMongoCollection<Product> _products;

        public ProductCollectionRepository(IMongoConnection connection)
        {
            _products = connection.GetCollection<Product>(MongoCollections.Products);
        }

        public async Task<bool> Add(Product entity)
        {
            await _products.InsertOneAsync(entity);
            return true;
        }

        public async Task<(List<Product>, int)> Find(Guid subcategory, ProductFilter filter)
        {
            var registers = await _products.FindAsync(Builders<Product>.Filter.Empty);
            var products = await registers.ToListAsync();

            IEnumerable<Product> query = products;

            query = query.Where(x => x.SubcategoryId == subcategory);                        

            if (filter.Brands != null && filter.Brands.Count > 0)
            {
                query = query.Where(x => filter.Brands.Any(y => y == x.BrandId)); //Guid.Parse(y)
            }

            if (filter.FreeShipping)
            {
                query = query.Where(x => x.FreeShipping == true);
            }

            switch (filter.PriceType)
            {
                case PriceType.Between0To25:
                    query = query.Where(x => x.Price >= 0 && x.Price <= 25);
                    break;
                case PriceType.Between26To50:
                    query = query.Where(x => x.Price >= 26 && x.Price <= 50);
                    break;
                case PriceType.Between51To100:
                    query = query.Where(x => x.Price >= 51 && x.Price <= 100);
                    break;
                case PriceType.Greeter100:
                    query = query.Where(x => x.Price > 100);
                    break;
                default:                    
                    break;
            }

            switch (filter.RatingType)
            {
                case RatingType.Rating1:
                    query = query.Where(x => x.Rating == 1);
                    break;
                case RatingType.Rating2:
                    query = query.Where(x => x.Rating == 2);
                    break;
                case RatingType.Rating3:
                    query = query.Where(x => x.Rating == 3);
                    break;
                case RatingType.Rating4:
                    query = query.Where(x => x.Rating == 4);
                    break;
                case RatingType.Rating5:
                    query = query.Where(x => x.Rating == 5);
                    break;
                default:
                    break;
            }

            switch (filter.OrderType)
            {
                case OrderType.LowestPrice:
                    query = query.OrderBy(x => x.Price);
                    break;
                default:
                    break;
            }

            var list = query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList();
            var count = query.Count();

            return (list, count);
        }

        public async Task<bool> Remove(Guid id)
        {
            await _products.DeleteOneAsync(Builders<Product>.Filter.Eq("_id", id));
            return true;
        }

        public async Task<bool> Update(Product entity)
        {
            await _products.ReplaceOneAsync(Builders<Product>.Filter.Eq("_id", entity.Id), entity);
            return true;
        }
    }
}
