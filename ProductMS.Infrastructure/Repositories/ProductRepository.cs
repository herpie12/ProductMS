using Microsoft.EntityFrameworkCore;
using ProductMS.Domain.Models;
using ProductMS.Domain.Repositories;
using ProductMS.Infrastructure.Data.Context;

namespace ProductMS.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _productDbContext;

        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
        public async Task<bool> CreateProduct(Product product)
        {
            _productDbContext.Products.Add(product);

            return await _productDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Deactivate(int id)
        {
            var product = await _productDbContext.Products.FirstAsync(p => p.Id == id);
            if (product is null)
            {
                throw new ArgumentException($"Product does not exist: {id}");
            }

            product.DeactivateProduct();

            return await _productDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _productDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product is null)
            {
                throw new ArgumentException($"Product does not exist: {id}");
            }
            _productDbContext.Products.Remove(product);

            return await _productDbContext.SaveChangesAsync() > 0; 
        }

        public async Task<IEnumerable<Product>> GetProducts(CancellationToken cancellationToken)
        {
            return await _productDbContext.Products.ToListAsync(cancellationToken);
        }

        public async Task<int> ProductCount()
        {
            return await _productDbContext.Products.CountAsync();
        }

        public async Task<bool> Save()
        {
            return await _productDbContext.SaveChangesAsync() > 0;
        }
    }
}
