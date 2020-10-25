using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakery.Api.Services;
using Bakery.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bakery.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsService _service;

        public ProductsController(ILogger<ProductsController> logger, IProductsService service)
        {
            (_logger, _service) = (logger, service);
        }

        [HttpGet]
        [Route("/all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            if (!result?.Any() ?? false)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            await _service.UpdateAsync(product).ConfigureAwait(false);

            return NoContent();
        }
    }
}
