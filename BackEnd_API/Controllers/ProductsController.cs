using Application_Services.IService;
using Common_API.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackEnd_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// api/products/all-product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("all-product")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllProductPagging([FromQuery] GetAllProductAPI request)
        {
            var result = await _productService.GetAllProductPaging(request);

            return Ok(result);
        }

        /// <summary>
        /// /api/products/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductById([FromQuery] int id)
        {
            var result = await _productService.GetProductById(id);

            return Ok(result);
        }
    }
}
