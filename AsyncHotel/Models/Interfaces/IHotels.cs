using AsyncHotel.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.Interfaces
{
    public interface IHotels
    {
        /// <summary>
        /// creates a new hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>the created hotel object</returns>
        Task<Hotels> Create(Hotels hotel);

        /// <summary>
        /// get's a specific hotel
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>the hotel's information in DTO format</returns>
        Task<HotelsDTO> GetHotel(int ID);

        /// <summary>
        /// get all hotels
        /// </summary>
        /// <returns>a list of all hotel DTOs</returns>
        Task<List<HotelsDTO>> GetHotels();

        /// <summary>
        /// update one hotel's data
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="hotel"></param>
        /// <returns>the updated hotel</returns>
        Task<Hotels> UpdateHotel(int ID, Hotels hotel);

        /// <summary>
        /// delete a specific hotel
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>200 OK</returns>
        Task DeleteHotel(int ID);
    }
}
