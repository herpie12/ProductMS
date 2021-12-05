using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductMS.Application.Commands.CreateProducts;
using ProductMS.Application.Commands.DeleteProduct;
using ProductMS.Application.DtoModels;
using ProductMS.Application.Queries.GetProductCount;
using ProductMS.Application.Queries.GetProducts;
using System.Net;

namespace ProductMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IMediator _mediator;

        public ProductsController(ILogger<ProductsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            _logger.LogInformation("----> Get ProductList");

            return Ok(await _mediator.Send(new GetProductListQuery(), cancellationToken));
        }


        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [HttpGet("count")]
        public async Task<IActionResult> GetProductCount()
        {
            _logger.LogInformation("----> Get Product count");

            return Ok(await _mediator.Send(new GetProductCountQuery()));
        }


        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            _logger.LogInformation($"----> Insert Product {productDto.Name}");

            return Ok(await _mediator.Send(new CreateProductCommand(productDto)));
        }


        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            _logger.LogInformation($"----> deleting Product {id}");

            return Ok(await _mediator.Send(new DeleteProductCommand(id)));
        }
    }
}
