namespace ECommerce.Infra.Context.Mongo.Configuration
{
    public class MongoDatabaseSettings : IMongoDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
