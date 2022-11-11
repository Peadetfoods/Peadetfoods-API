using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Peadetfoods.Domain.Exceptions;
using Peadetfoods.Infrastructure.CQRS.Commands.AddProductImage;

namespace Peadetfoods.Api.Controllers.Products
{
    [Route("api/products")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<ProductImagesController> _logger;

        public ProductImagesController(IMapper mapper, IMediator mediator, ILogger<ProductImagesController> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("{productId}/images")]
        public async Task<IActionResult> AddProductImage(long productId, [FromForm] AddProductImageRequest request)
        {
            try
            {
                var command = new AddProductImageCommand
                {
                    ProductId = productId,
                    Image = request.Image
                };

                var result = await _mediator.Send(command);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding product image", request);

                return StatusCode(500);
            }
        }
    }
}
