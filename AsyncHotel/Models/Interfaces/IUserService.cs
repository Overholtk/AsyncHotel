using AsyncHotel.Models.API;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> Register(RegisteredUser data, ModelStateDictionary model);

        public Task<UserDTO> Authenticate(String userName, string password);
    }
}
