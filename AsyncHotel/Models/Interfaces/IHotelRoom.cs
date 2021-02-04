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
        Task<HotelRoom> Create(int hotelID, int roomNumber);

        //Read
        Task<HotelRoom> GetHotelRoom(int ID, int RoomNumber);
        Task<List<HotelRoom>> GetHotelRooms(int ID);

        //Update
        Task<HotelRoom> UpdateHotelRoom(int hotelID, int roomNumber, HotelRoom hotelRoom);

        //Delete
        Task Delete(int HotelID, int roomNumber);

        
    }
}
