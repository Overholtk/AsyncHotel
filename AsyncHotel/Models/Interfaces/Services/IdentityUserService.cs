using AsyncHotel.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.Interfaces.Services
{
    public class IdentityUserService : IUserService
    {

        public async Task<UserDTO> Register(RegisteredUser data)
        {
            throw new NotImplementedException();
        }
    }
}
