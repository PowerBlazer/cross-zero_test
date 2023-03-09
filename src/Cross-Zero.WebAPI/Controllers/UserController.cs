using Cross_Zero.Core.Context;
using Cross_Zero.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cross_Zero.WebAPI.Controllers
{
    [Route("user")]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getusers")]
        public async Task<IActionResult> GetAllUsers([FromServices]IApplicationContextEF context) 
        {
            var res = await context.Users.ToListAsync();

            return Ok(res);
        }
    }
}
