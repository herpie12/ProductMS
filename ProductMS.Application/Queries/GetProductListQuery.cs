using MediatR;
using ProductMS.Application.DtoModels;

namespace ProductMS.Application.Queries
{
    public record GetProductListQuery : IRequest<IEnumerable<ProductDto>>;
}
