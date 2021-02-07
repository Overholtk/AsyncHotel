using AsyncHotel.Models;
using AsyncHotel.Models.API;
using AsyncHotel.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService service)
        {
            _userService = service;
        }

        
        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisteredUser data)
        {
            var user = await _userService.Register(data, this.ModelState);
            if (ModelState.IsValid)
            {
                return user;
            }
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginData data)
        {
            var user = await _userService.Authenticate(data.UserName, data.Password);
            if(user != null)
            {
                return user;
            }

            return Unauthorized();
        }
    }
}
