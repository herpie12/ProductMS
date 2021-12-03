using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductMS.Application.Commands.CreateProducts;
using ProductMS.Application.DtoModels;
using ProductMS.Application.Queries.GetProductCount;
using ProductMS.Application.Queries.GetProducts;
using ProductMS.Domain.Repositories;
using ProductMS.Infrastructure.Repositories;

namespace ProductMS.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //Core layer
            service.AddScoped<IProductRepository, ProductRepository>();


            //Query handlers
            service.AddTransient<GetProductHandler>();
            service.AddTransient<IRequestHandler<GetProductListQuery, IEnumerable<ProductDto>>, GetProductHandler>();

            //Query handlers
            service.AddTransient<GetProductCountHandler>();
            service.AddTransient<IRequestHandler<GetProductCountQuery, int>, GetProductCountHandler>();

            //Command handlers
            service.AddTransient<CreateProductHandler>();
            service.AddTransient<IRequestHandler<CreateProductCommand, bool>, CreateProductHandler>();

        }
    }
}
