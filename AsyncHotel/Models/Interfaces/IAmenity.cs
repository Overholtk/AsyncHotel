using AsyncHotel.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.Interfaces
{
    public interface IAmenity
    {
        /// <summary>
        /// create a new amenity
        /// </summary>
        /// <param name="amenity"></param>
        /// <returns>the amenity created</returns>
        Task<Amenity> Create(AmenityDTO amenity);

        /// <summary>
        /// get a specific amenity
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>the chosen amenity's DTO</returns>
        Task<AmenityDTO> GetAmenity(int ID);

        /// <summary>
        /// display all amenities
        /// </summary>
        /// <returns>a list of all amenity DTOs</returns>
        Task<List<AmenityDTO>> GetAmenities();

        /// <summary>
        /// update a specific amenity
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="amenity"></param>
        /// <returns>the updated amenity</returns>
        Task<Amenity> UpdateAmenity(int ID, Amenity amenity);

        /// <summary>
        /// delete a specific amenity
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>200 completed</returns>
        Task DeleteAmenity(int ID);
    }
}
