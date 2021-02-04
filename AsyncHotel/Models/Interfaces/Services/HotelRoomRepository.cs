using AsyncHotel.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.Interfaces.Services
{
    public class HotelRoomRepository : IHotelRoom
    {

        private AsyncInnDBContext _context;

        public HotelRoomRepository(AsyncInnDBContext context)
        {
            _context = context;
        }

        public async Task<HotelRoom> Create(int hotelID, int roomNumber)
        {
            HotelRoom hotelRoom = new HotelRoom()
            {
                HotelsID = hotelID,
                RoomNumber = roomNumber
            };
            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task Delete(int hotelID, int roomNumber)
        {
            HotelRoom hotelRoom = await GetHotelRoom(hotelID, roomNumber);
            _context.Entry(hotelRoom).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }


        public async Task<HotelRoom> GetHotelRoom(int ID, int RoomNumber)
        {
            var result = await _context.HotelRooms.FirstOrDefaultAsync(x => x.HotelsID == ID && x.RoomNumber == RoomNumber);
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.ID == result.RoomID);
            var ames = await _context.RoomAmenities.Where(x => x.RoomID == result.RoomID).ToListAsync();
            result.Room = room;
            result.Room.RoomAmenities = ames;
            return result;
        }

        public async Task<List<HotelRoom>> GetHotelRooms(int hotelID)
        {
            var roomsList = await _context.HotelRooms.Where(x => x.HotelsID == hotelID)
                .ToListAsync();
            return roomsList;
        }

        //TODO: write this lol
        public async Task<HotelRoom> UpdateHotelRoom(int hotelID, int roomNumber, HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }
    }
}
