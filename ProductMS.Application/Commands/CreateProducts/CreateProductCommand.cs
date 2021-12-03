using MediatR;
using ProductMS.Application.DtoModels;

namespace ProductMS.Application.Commands.CreateProducts
{
    public class CreateProductCommand : IRequest<bool>
    {
        public ProductDto ProductDto;

        public CreateProductCommand(ProductDto productDto)
        {
            ProductDto = productDto;
        }
    }
}
