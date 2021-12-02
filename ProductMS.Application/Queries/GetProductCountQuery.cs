using MediatR;

namespace ProductMS.Application.Queries
{
    public record GetProductCountQuery : IRequest<int>;
}
