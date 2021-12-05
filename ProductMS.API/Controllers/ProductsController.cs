using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductMS.Application.Commands.CreateProducts;
using ProductMS.Application.Commands.DeleteProduct;
using ProductMS.Application.DtoModels;
using ProductMS.Application.Queries.GetProductCount;
using ProductMS.Application.Queries.GetProducts;

namespace ProductMS.API.Controllers
{
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            _logger.LogInformation("----> Get ProductList");

            return Ok(await _mediator.Send(new GetProductListQuery(), cancellationToken));
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetProductCount()
        {
            _logger.LogInformation("----> Get Product count");

            return Ok(await _mediator.Send(new GetProductCountQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            _logger.LogInformation($"----> Insert Product {productDto.Name}");

            return Ok(await _mediator.Send(new CreateProductCommand(productDto)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            _logger.LogInformation($"----> deleting Product {id}");

            return Ok(await _mediator.Send(new DeleteProductCommand(id)));
        }
    }
}
