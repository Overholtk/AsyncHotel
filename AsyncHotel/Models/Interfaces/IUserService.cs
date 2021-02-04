using AsyncHotel.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> Register(RegisteredUser data);
    }
}
