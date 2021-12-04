using MediatR;

namespace ProductMS.Application.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id;
        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
