using System.Linq;
using System.Threading.Tasks;
using Bakery.Api.Services;
using Bakery.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bakery.Api.Controllers
{
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrdersService _service;

        public OrdersController(ILogger<OrdersController> logger, IOrdersService service)
        {
            (_logger, _service) = (logger, service);
        }

        [HttpGet]
        [Authorize]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            if (!result?.Any() ?? false)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("all/{phoneNumber}")]
        public async Task<IActionResult> GetByPhoneNumber([FromRoute] string phoneNumber)
        {
            var result = await _service.GetByPhoneNumber(phoneNumber);

            if (!result?.Any() ?? false)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] Order order)
        {
            if (!ModelState.IsValid)
                return BadRequest(order);

            await _service.UpdateAsync(order).ConfigureAwait(false);

            return NoContent();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _service.CreateAsync(order).ConfigureAwait(false);

            return CreatedAtAction("CreateOrder", order);
        }
    }
}
