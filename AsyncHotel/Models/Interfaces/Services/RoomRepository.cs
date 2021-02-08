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

        /// <summary>
        /// sets context to DB
        /// </summary>
        /// <param name="context"></param>
        public RoomRepository(AsyncInnDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// creates a new room
        /// </summary>
        /// <param name="incomingData">the inputted data in DTO format</param>
        /// <returns>created room</returns>
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

        /// <summary>
        /// deltes a room
        /// </summary>
        /// <param name="ID">the ID of the room to be deleted</param>
        /// <returns></returns>
        public async Task Delete(int ID)
        {
            RoomDTO roomdto = await GetRoom(ID);
            Room room = await _context.Rooms.FirstOrDefaultAsync(r => r.ID == roomdto.ID);
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();

        }

        /// <summary>
        /// gets a specific room
        /// </summary>
        /// <param name="ID">the ID of the room to be retrieved</param>
        /// <returns>the DTO of the created room  </returns>
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

        /// <summary>
        /// get all rooms
        /// </summary>
        /// <returns>a list of all room DTOs</returns>
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

        /// <summary>
        /// update a specific room
        /// </summary>
        /// <param name="ID">the ID of the room to be updated</param>
        /// <param name="room">the new data</param>
        /// <returns>the updated room</returns>
        public async Task<Room> UpdateRoom(int ID, Room room)
        {
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

        /// <summary>
        /// add an amenity to a room
        /// </summary>
        /// <param name="amenityID">the ID of the amenity to be added</param>
        /// <param name="roomID">the ID of the room to add it to</param>
        /// <returns></returns>
        public async Task AddAmenityToRoom(int amenityID, int roomID)
        {
            RoomAmenities roomAmenities = new RoomAmenities() { AmenityID = amenityID, RoomID = roomID };

            _context.Entry(roomAmenities).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// removes an amenity from a room
        /// </summary>
        /// <param name="roomID">the room to be removed from</param>
        /// <param name="amenityID">the amenity to be removed</param>
        /// <returns></returns>
        public async Task RemoveAmenityFromRoom(int roomID, int amenityID)
        {
            var result = await _context.RoomAmenities.FirstOrDefaultAsync(x => x.AmenityID == amenityID && x.RoomID == roomID);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
