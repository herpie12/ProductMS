using MediatR;
using ProductMS.Application.DtoModels;

namespace ProductMS.Application.Queries.GetProducts
{
    public record GetProductsQuery : IRequest<IEnumerable<ProductDto>>;
}
