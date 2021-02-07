using AsyncHotel.Models;
using AsyncHotel.Models.API;
using AsyncHotel.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        //
        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisteredUser data)
        {
            var user = await _userService.Register(data);
            return user;
        }
    }
}
