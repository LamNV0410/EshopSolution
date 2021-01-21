using Application_Services;
using Common_API.Request;
using Common_API.Respone;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackEnd_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] APIUserLoginRequest userLoginRequest)
        {
            APIResponse<string> result = await _userService.Authenticate(userLoginRequest);
            return Ok(result);
        }
    }
}
