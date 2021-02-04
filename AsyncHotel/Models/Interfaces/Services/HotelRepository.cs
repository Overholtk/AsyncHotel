using AsyncHotel.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.Interfaces.Services
{
    public class HotelRepository : IHotels
    {
        private AsyncInnDBContext _context;

        public HotelRepository(AsyncInnDBContext context)
        {
            _context = context;
        }

        public async Task<Hotels> Create(Hotels hotel)
        {
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Added;

            await _context.SaveChangesAsync();

            return hotel;
        }

        public async Task DeleteHotel(int ID)
        {
            Hotels hotel = await GetHotel(ID);
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Hotels> GetHotel(int ID)
        {
            Hotels hotel = await _context.Hotels.FindAsync(ID);
            var hotelRooms = await _context.HotelRooms.Where(x => x.HotelsID == ID).Include(x => x.Room).Include(x => x.Room.RoomAmenities).ToListAsync();
            hotel.hotelRooms = hotelRooms;
            return hotel;
        }

        public async Task<List<Hotels>> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

        public async Task<Hotels> UpdateHotel(int ID, Hotels hotel)
        {
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
