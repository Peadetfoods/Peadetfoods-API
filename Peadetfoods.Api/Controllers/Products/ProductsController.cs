using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Peadetfoods.Infrastructure.Common;
using Peadetfoods.Infrastructure.CQRS.Commands.CreateProduct;
using Peadetfoods.Infrastructure.CQRS.Queries;
using Peadetfoods.Infrastructure.Dtos;

namespace Peadetfoods.Api.Controllers.Products
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductsQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<PagedList<ProductDto>>(result));
        }

        [HttpGet("{productId:long}")]
        public async Task<IActionResult> GetProduct(long productId)
        {
            var result = await _mediator.Send(new GetProductQuery { ProductId = productId });
            return Ok(_mapper.Map<ProductDto>(result));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand request)
        {
            try
            {
                var result = await _mediator.Send(request);
                return Ok(_mapper.Map<ProductDto>(result));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
