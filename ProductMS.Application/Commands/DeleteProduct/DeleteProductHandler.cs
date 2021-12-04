using MediatR;
using ProductMS.Domain.Repositories;

namespace ProductMS.Application.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           var productIsDeleted = await _productRepository.DeleteProduct(request.Id);

            return productIsDeleted;
        }
    }
}
