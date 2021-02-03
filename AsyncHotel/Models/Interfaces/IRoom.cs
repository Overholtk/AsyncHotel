using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.Interfaces
{
    public interface IRoom
    {
        Task<Room> Create(Room room);
        Task<Room> GetRoom(int ID);
        Task<List<Room>> GetRooms();
        Task<Room> UpdateRoom(int ID, Room room);
        Task Delete(int ID);

        Task AddAmenityToRoom(int amenityID, int roomID);
        Task RemoveAmenityFromRoom(int roomID, int amenityID);
    }
}
