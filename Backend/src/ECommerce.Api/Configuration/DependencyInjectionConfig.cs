using ECommerce.Application.Services;
using ECommerce.Core.Communication.Mediator;
using ECommerce.Core.Notifications;
using ECommerce.Domain.Events;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;
using ECommerce.Infra.Context;
using ECommerce.Infra.Context.EF;
using ECommerce.Infra.Context.Mongo;
using ECommerce.Infra.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ECommerce.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ECommerceDbContext>();            
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCollectionRepository, ProductCollectionRepository>();
            services.AddScoped<IBrandCollectionRepository, BrandCollectionRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

            services.AddScoped<IMongoConnection, MongoConnection>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<INotificationHandler<ProductAddEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductRemoveEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductUpdateEvent>, ProductEventHandler>();

            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISubcategoryService, SubcategoryService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}