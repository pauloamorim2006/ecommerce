using ECommerce.Infra.Context.Mongo.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ECommerce.Api.Configuration
{
    public static class MongoConfig
    {
        public static void MongoConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<MongoDatabaseSettings>(
                Configuration.GetSection(nameof(MongoDatabaseSettings)));

            services.AddSingleton<IMongoDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoDatabaseSettings>>().Value);
        }
    }
}
