using AsyncHotel.Data;
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
        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Added;

            await _context.SaveChangesAsync();

            return room;
        }

        public async Task Delete(int ID)
        {
            Room room = await GetRoom(ID);
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();

        }

        public async Task<Room> GetRoom(int ID)
        {
            Room room = await _context.Rooms.FindAsync(ID);
            return room;
        }

        public async Task<List<Room>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return rooms;
        }

        public async Task<Room> UpdateRoom(int ID, Room room)
        {
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
    }
}
