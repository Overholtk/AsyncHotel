using AsyncHotel.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.Interfaces
{
    public interface IHotelRoom
    {
       /// <summary>
       /// create a new hotel room
       /// </summary>
       /// <param name="hotelID"></param>
       /// <param name="roomNumber"></param>
       /// <param name="incomingData"></param>
       /// <returns>the created hotel room</returns>
        Task<HotelRoom> Create(int hotelID, int roomNumber, HotelRoomDTO incomingData);

        /// <summary>
        /// get a specific hotel room
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="RoomNumber"></param>
        /// <returns>the hotel room's DTO</returns>
        Task<HotelRoomDTO> GetHotelRoom(int ID, int RoomNumber);

        /// <summary>
        /// get all hotel rooms
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>a list of all hotel room DTOs</returns>
        Task<List<HotelRoomDTO>> GetHotelRooms(int ID);

        /// <summary>
        /// update a hotel room
        /// </summary>
        /// <param name="hotelID"></param>
        /// <param name="roomNumber"></param>
        /// <param name="incomingData"></param>
        /// <returns>the updated hotel room</returns>
        Task<HotelRoom> UpdateHotelRoom(int hotelID, int roomNumber, HotelRoomDTO incomingData);

        /// <summary>
        /// delete a hotel room
        /// </summary>
        /// <param name="HotelID"></param>
        /// <param name="roomNumber"></param>
        /// <returns>200 OK</returns>
        Task Delete(int HotelID, int roomNumber);

        
    }
}
