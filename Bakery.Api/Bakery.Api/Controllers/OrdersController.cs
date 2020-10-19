using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakery.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bakery.Api.Controllers
{
    [ApiController]
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
        [Route("/all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();

            if (!result?.Any() ?? false)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("/all/{phoneNumber}")]
        public async Task<IActionResult> GetByPhoneNumber([FromRoute] string phoneNumber)
        {
            var result = await _service.GetByPhoneNumber(phoneNumber);

            if (!result?.Any() ?? false)
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}
