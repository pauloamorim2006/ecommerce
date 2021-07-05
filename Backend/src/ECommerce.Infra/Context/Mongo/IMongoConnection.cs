using MongoDB.Driver;

namespace ECommerce.Infra.Context.Mongo
{
    public interface IMongoConnection
    {
        IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}
