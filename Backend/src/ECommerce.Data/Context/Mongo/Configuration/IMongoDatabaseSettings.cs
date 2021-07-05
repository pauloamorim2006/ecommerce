namespace ECommerce.Infra.Context.Mongo.Configuration
{
    public interface IMongoDatabaseSettings
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}
