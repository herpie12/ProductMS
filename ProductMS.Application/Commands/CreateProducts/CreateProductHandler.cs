using MediatR;
using ProductMS.Application.DtoModels;
using ProductMS.Application.Services.EventBus;
using ProductMS.Domain.DomainEvents;
using ProductMS.Domain.Models;
using ProductMS.Domain.Repositories;

namespace ProductMS.Application.Commands.CreateProducts
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IEventBus _bus;
        public CreateProductHandler(IProductRepository productRepository, IEventBus bus)
        {
            _productRepository = productRepository;
            _bus = bus;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productIsSaved = await _productRepository.CreateProduct(Map(request.ProductDto));

            if (productIsSaved)
            {
                _bus.Publish(new ProductCreatedEvent(request.ProductDto.Name, request.ProductDto.IsActive, request.ProductDto.Fee));
            }

            return productIsSaved;
        }
        private Product Map(ProductDto productDto)
        => new Product(productDto.Name, productDto.IsActive, productDto.ProductType, productDto.Fee);
    }
}
