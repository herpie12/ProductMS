using ProductMS.Domain.Models;

namespace ProductMS.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(CancellationToken cancellationToken);

        Task<bool> CreateProduct(Product product);

        Task<bool> DeleteProduct(int id);

        Task<bool> Deactivate(int id);

        Task<int> ProductCount();

        Task<bool> Save();
    }
}
