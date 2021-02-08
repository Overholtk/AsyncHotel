using AsyncHotel.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.Interfaces
{
    public interface IRoom
    {
        /// <summary>
        /// create a new room
        /// </summary>
        /// <param name="incomingData"></param>
        /// <returns>the created room object</returns>
        Task<Room> Create(RoomDTO incomingData);

        /// <summary>
        /// display a specific room
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>specific room's DTO</returns>
        Task<RoomDTO> GetRoom(int ID);

        /// <summary>
        /// get all rooms
        /// </summary>
        /// <returns>a list of all room DTOs</returns>
        Task<List<RoomDTO>> GetRooms();

        /// <summary>
        /// update this a specific room
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="room"></param>
        /// <returns>the updated room</returns>
        Task<Room> UpdateRoom(int ID, Room room);

        /// <summary>
        /// delete a specific room
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>200 Ok</returns>
        Task Delete(int ID);

        /// <summary>
        /// Adds an amenity to a room
        /// </summary>
        /// <param name="amenityID"></param>
        /// <param name="roomID"></param>
        /// <returns>success or fail</returns>
        Task AddAmenityToRoom(int amenityID, int roomID);

        /// <summary>
        /// Removes an amenity from a room
        /// </summary>
        /// <param name="roomID"></param>
        /// <param name="amenityID"></param>
        /// <returns>successs or fail</returns>
        Task RemoveAmenityFromRoom(int roomID, int amenityID);
    }
}
