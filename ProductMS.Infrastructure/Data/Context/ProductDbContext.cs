using Microsoft.EntityFrameworkCore;
using ProductMS.Domain.Models;

namespace ProductMS.Infrastructure.Data.Context
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
