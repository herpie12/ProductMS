using MediatR;
using ProductMS.Application.DtoModels;
using ProductMS.Domain.Models;
using ProductMS.Domain.Repositories;

namespace ProductMS.Application.Commands
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productIsSaved = await _productRepository.CreateProduct(Map(request.ProductDto));

            return productIsSaved;
        }
        private Product Map(ProductDto productDto)
        => new Product(productDto.Name, productDto.IsActive, productDto.ProductType, productDto.Fee);
    }
}
