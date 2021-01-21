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
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailsService _orderDetailsService;
        public OrderDetailController(IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        [HttpGet("all-orderdetails")]
        public async Task<IActionResult> GetOrderDetails([FromQuery] int id)
        {
            var orderDetails = await _orderDetailsService.GetOrderDetails(id);
            return Ok(orderDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById([FromQuery] int orderId, int productId)
        {
            var orderDetail = await _orderDetailsService.GetOrderDetailById(orderId, productId);
            return Ok(orderDetail);
        }
    }
}
