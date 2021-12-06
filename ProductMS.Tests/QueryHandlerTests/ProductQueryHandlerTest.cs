using Moq;
using ProductMS.Application.Queries.GetProducts;
using ProductMS.Domain.Models;
using ProductMS.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace ProductMS.Tests.QueryHandlerTests
{
    public class ProductQueryHandlerTest
    {
        private readonly Mock<IProductRepository> _productRepository;

        public ProductQueryHandlerTest()
        {
            _productRepository = new Mock<IProductRepository>();   
        }

        [Fact]
        public void Get_Products_ContainsElement()
        {
            var product = new Product("test", true, ProductType.Loans, 0m);
            var productList = new List<Product>();
            productList.Add(product);
    
            //repo setup
            _productRepository.Setup(p => p.GetProducts(new CancellationToken())).ReturnsAsync(productList);

            //handler setup
            var getProductQuery = new GetProductsQuery();
            var getProductQueryHandler = new GetProductsQueryHandler(_productRepository.Object);
            var result = getProductQueryHandler.Handle(getProductQuery, new CancellationToken()).Result;

            Assert.Single(result);
        }
    }
}
