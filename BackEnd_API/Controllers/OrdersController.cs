using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application_Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // TODO : Authorize
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetOrder([FromQuery]Guid id)
        {
            var orders = await _orderService.GetOrders(id);

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById([FromQuery] Guid id, int orderId)
        {
            var order = await _orderService.GetOrderById(id, orderId);
            return Ok(order);
        }
    }
}
