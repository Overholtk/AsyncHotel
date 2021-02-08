using AsyncHotel.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.Interfaces
{
    public interface IRoom
    {
        Task<Room> Create(RoomDTO incomingData);
        Task<RoomDTO> GetRoom(int ID);
        Task<List<RoomDTO>> GetRooms();
        Task<Room> UpdateRoom(int ID, Room room);
        Task Delete(int ID);

        Task AddAmenityToRoom(int amenityID, int roomID);
        Task RemoveAmenityFromRoom(int roomID, int amenityID);
    }
}
