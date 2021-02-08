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
        /// <summary>
        /// registers a new user
        /// </summary>
        /// <param name="data"></param>
        /// <param name="model"></param>
        /// <returns>returns the user's DTO data</returns>
        public Task<UserDTO> Register(RegisteredUser data, ModelStateDictionary model);

        /// <summary>
        /// chekcs user capabilites
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>user's DTO data</returns>
        public Task<UserDTO> Authenticate(String userName, string password);
    }
}
