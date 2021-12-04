using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductMS.Application.Commands.CreateProducts;
using ProductMS.Application.Commands.DeleteProduct;
using ProductMS.Application.DtoModels;
using ProductMS.Application.Queries.GetProductCount;
using ProductMS.Application.Queries.GetProducts;
using ProductMS.Application.Services.EventBus;
using ProductMS.Domain.Repositories;
using ProductMS.Infrastructure.Repositories;

namespace ProductMS.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //EventBus
            services.AddSingleton<IEventBus, RabbitMQBus>();

            //Core layer
            services.AddScoped<IProductRepository, ProductRepository>();


            //Query handlers
            services.AddTransient<GetProductHandler>();
            services.AddTransient<IRequestHandler<GetProductListQuery, IEnumerable<ProductDto>>, GetProductHandler>();

            //Query handlers
            services.AddTransient<GetProductCountHandler>();
            services.AddTransient<IRequestHandler<GetProductCountQuery, int>, GetProductCountHandler>();

            //Command handlers
            services.AddTransient<CreateProductHandler>();
            services.AddTransient<IRequestHandler<CreateProductCommand, bool>, CreateProductHandler>();

            services.AddTransient<DeleteProductHandler>();
            services.AddTransient<IRequestHandler<DeleteProductCommand, bool>, DeleteProductHandler>();

        }
    }
}
