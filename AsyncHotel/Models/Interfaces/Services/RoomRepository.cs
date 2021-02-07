using AsyncHotel.Data;
using AsyncHotel.Models.API;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.Interfaces.Services
{
    public class RoomRepository : IRoom
    {
        private AsyncInnDBContext _context;

        public RoomRepository(AsyncInnDBContext context)
        {
            _context = context;
        }
        public async Task<Room> Create(RoomDTO incomingData)
        {
            Room room = new Room
            {
                ID = incomingData.ID,
                Nickname = incomingData.Name,
                Layout = Int32.Parse(incomingData.Layout),
            };

            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task Delete(int ID)
        {
            RoomDTO roomdto = await GetRoom(ID);
            Room room = await _context.Rooms.FirstOrDefaultAsync(r => r.ID == roomdto.ID);
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();

        }

        public async Task<RoomDTO> GetRoom(int ID)
        {
            return await _context.Rooms
                .Select(room => new RoomDTO
                {
                    ID = room.ID,
                    Name = room.Nickname,
                    Layout = room.Layout.ToString(),
                    Amenities = room.RoomAmenities
                    .Select(amenity => new AmenityDTO
                    {
                        ID = amenity.Amenity.ID,
                        Name = amenity.Amenity.Name,
                    }).ToList()

                }).FirstOrDefaultAsync(r => r.ID == ID);
        }

        
        public async Task<List<RoomDTO>> GetRooms()
        {
            var rooms = await _context.Rooms
                .Select(room => new RoomDTO
                {
                    ID = room.ID,
                    Name = room.Nickname,
                    Layout = room.Layout.ToString(),
                    Amenities = room.RoomAmenities
                    .Select(am => new AmenityDTO
                    {
                        ID = am.Amenity.ID,
                        Name = am.Amenity.Name,
                    }).ToList()
                }).ToListAsync();
            return rooms;
        }

        public async Task<Room> UpdateRoom(int ID, Room room)
        {
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task AddAmenityToRoom(int amenityID, int roomID)
        {
            RoomAmenities roomAmenities = new RoomAmenities() { AmenityID = amenityID, RoomID = roomID };

            _context.Entry(roomAmenities).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmenityFromRoom(int roomID, int amenityID)
        {
            var result = await _context.RoomAmenities.FirstOrDefaultAsync(x => x.AmenityID == amenityID && x.RoomID == roomID);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
