using MediatR;

namespace ProductMS.Application.Queries.GetProductCount
{
    public record GetProductCountQuery : IRequest<int>;
}
