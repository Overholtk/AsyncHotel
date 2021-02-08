using AsyncHotel.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.Interfaces
{
    public interface IHotelRoom
    {
        //CRUD Operations:

        //Create
        Task<HotelRoom> Create(int hotelID, int roomNumber, HotelRoomDTO incomingData);

        //Read
        Task<HotelRoomDTO> GetHotelRoom(int ID, int RoomNumber);
        Task<List<HotelRoomDTO>> GetHotelRooms(int ID);

        //Update
        Task<HotelRoom> UpdateHotelRoom(int hotelID, int roomNumber, HotelRoomDTO incomingData);

        //Delete
        Task Delete(int HotelID, int roomNumber);

        
    }
}
