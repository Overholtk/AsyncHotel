using AsyncHotel.Data;
using AsyncHotel.Models.API;
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
            HotelsDTO hoteldto = await GetHotel(ID);
            Hotels hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.ID == hoteldto.ID);
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelsDTO> GetHotel(int ID)
        {
            return await _context.Hotels
                .Select(hotel => new HotelsDTO
                {
                    ID = ID,
                    Name = hotel.Name,
                    StreetAddress = hotel.StreetAddress,
                    City = hotel.City,
                    State = hotel.State,
                    Phone = hotel.PhoneNumber,
                    Rooms = hotel.hotelRooms
                    .Select(room => new RoomDTO
                    {
                        ID = room.Room.ID,
                        Name = room.Room.Nickname,
                        Layout = room.Room.Layout.ToString(),
                        Amenities = room.Room.RoomAmenities
                        .Select(am => new AmenityDTO
                        {
                            ID = am.Amenity.ID,
                            Name = am.Amenity.Name,
                        }).ToList()
                    }).ToList()
                }).FirstOrDefaultAsync();
        }

        public async Task<List<HotelsDTO>> GetHotels()
        {
            return await _context.Hotels
                .Select(hotel => new HotelsDTO
                {
                    ID = hotel.ID,
                    Name = hotel.Name,
                    StreetAddress = hotel.StreetAddress,
                    City = hotel.City,
                    State = hotel.State,
                    Phone = hotel.PhoneNumber,
                    Rooms = hotel.hotelRooms
                    .Select(room => new RoomDTO
                    {
                        ID = room.Room.ID,
                        Name = room.Room.Nickname,
                        Layout = room.Room.Layout.ToString(),
                        Amenities = room.Room.RoomAmenities
                        .Select(am => new AmenityDTO
                        {
                            ID = am.Amenity.ID,
                            Name = am.Amenity.Name,
                        }).ToList()
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<Hotels> UpdateHotel(int ID, Hotels hotel)
        {
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
