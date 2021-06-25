using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlassDoor.Models;
using GlassDoor.Services;

namespace GlassDoor.Controllers
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

        // new user signup
        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterModel model)
        {

            var result = await _userService.RegisterAsync(model);
            return Ok(result);
        }

        // login function
        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync(TokenRequestModel model)
        {
            var result = await _userService.GetTokenAsync(model);
            return Ok(result);
        }

        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync(AddRoleModel model)
        {
            var result = await _userService.AddRoleAsync(model);
            return Ok(result);
        }
    }
}
