using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
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

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(UserModel user)
        {
            var token = _userService.Login(user);
            if(token == null || token == string.Empty)
            {
                return BadRequest(new {message = "username or password is incorect" });
            }
            return Ok();
        }


    }
}
