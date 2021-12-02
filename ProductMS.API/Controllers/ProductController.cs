using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductMS.Application.Commands;
using ProductMS.Application.DtoModels;
using ProductMS.Application.Queries;

namespace ProductMS.API.Controllers
{
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;
        //private readonly IDistributedCache _distributedCache;

        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get(CancellationToken cancellationToken)
        {
            _logger.LogInformation("----> Get ProductList");
            return await _mediator.Send(new GetProductListQuery(), cancellationToken);
        }

        [HttpGet("productcount")]
        public async Task<int> GetProductCount()
        {
            _logger.LogInformation("----> Get Product count");
            return await _mediator.Send(new GetProductCountQuery());
        }

        [HttpPost("insertproduct")]
        public async Task<bool> CreateProduct([FromBody] ProductDto productDto)
        {
            _logger.LogInformation($"----> Insert Product {productDto.Name}");
            return await _mediator.Send(new CreateProductCommand(productDto));
        }

    }
}
