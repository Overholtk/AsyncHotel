using AsyncHotel.Data;
using AsyncHotel.Models.API;
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

        public async Task<HotelRoom> Create(int hotelID, int roomNumber, HotelRoomDTO incomingData)
        {
            HotelRoom hotelRoom = new HotelRoom()
            {
                HotelsID = hotelID,
                RoomNumber = roomNumber,
                RoomID = incomingData.RoomID,
                Rate = incomingData.Rate,
                PetFriendly = incomingData.PetFriendly
            };
            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task Delete(int hotelID, int roomNumber)
        {
            HotelRoomDTO hotelRoomdto = await GetHotelRoom(hotelID, roomNumber);
            HotelRoom hotelRoom = await _context.HotelRooms.FirstOrDefaultAsync(x => x.HotelsID == hotelRoomdto.HotelID && x.RoomNumber == hotelRoomdto.RoomNumber);
            _context.Entry(hotelRoom).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }


        public async Task<HotelRoomDTO> GetHotelRoom(int ID, int RoomNumber)
        {
            return await _context.HotelRooms
                .Select(room => new HotelRoomDTO
                {
                    HotelID = ID,
                    RoomNumber = RoomNumber,
                    Rate = room.Rate,
                    PetFriendly = room.PetFriendly,
                    RoomID = room.RoomID,
                    Room = new RoomDTO
                    {
                        ID = room.RoomID,
                        Name = room.Room.Nickname,
                        Layout = room.Room.Layout.ToString(),
                        Amenities = room.Room.RoomAmenities
                        .Select(am => new AmenityDTO
                        {
                            ID = am.AmenityID,
                            Name = am.Amenity.Name,
                        }).ToList(),
                    }
                }).FirstOrDefaultAsync();
        }

        public async Task<List<HotelRoomDTO>> GetHotelRooms(int hotelID)
        {
            return await _context.HotelRooms
                .Select(room => new HotelRoomDTO
                {
                    HotelID = hotelID,
                    RoomNumber = room.RoomNumber,
                    Rate = room.Rate,
                    PetFriendly = room.PetFriendly,
                    RoomID = room.RoomID,
                    Room = new RoomDTO
                    {
                        ID = room.RoomID,
                        Name = room.Room.Nickname,
                        Layout = room.Room.Layout.ToString(),
                        Amenities = room.Room.RoomAmenities
                        .Select(am => new AmenityDTO
                        {
                            ID = am.Amenity.ID,
                            Name = am.Amenity.Name,
                        }).ToList(),

                    }
                }).ToListAsync();
        }

        public async Task<HotelRoom> UpdateHotelRoom(int hotelID, int roomNumber, HotelRoomDTO incomingData)
        {

            HotelRoom room = await _context.HotelRooms.FirstOrDefaultAsync(x => x.HotelsID == hotelID && x.RoomNumber == roomNumber);
            room.Rate = incomingData.Rate;
            room.PetFriendly = incomingData.PetFriendly;
            room.RoomID = incomingData.RoomID;
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
    }
}
