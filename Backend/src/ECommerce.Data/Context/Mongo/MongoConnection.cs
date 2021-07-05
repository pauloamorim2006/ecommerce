using ECommerce.Infra.Context.Mongo.Configuration;
using MongoDB.Driver;

namespace ECommerce.Infra.Context.Mongo
{
    public class MongoConnection : IMongoConnection
    {
        private readonly IMongoDatabaseSettings _settings;

        public MongoConnection(IMongoDatabaseSettings settings)
        {
            _settings = settings;
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);

            return database.GetCollection<T>(collectionName);
        }
    }
}
