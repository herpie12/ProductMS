using MediatR;
using ProductMS.Application.DtoModels;
using ProductMS.Domain.Models;
using ProductMS.Domain.Repositories;

namespace ProductMS.Application.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProducts(cancellationToken);
            return products.Select(p => Map(p));
        }

        private ProductDto Map(Product product)
       => new ProductDto
       {
           Name = product.Name,
           IsActive = product.IsActive,
           ProductType = product.ProductType,
           Fee = product.Fee,
       };
    }
}
