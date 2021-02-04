using AsyncHotel.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.Interfaces.Services
{
    public class AmenityRepository : IAmenity
    {
        private AsyncInnDBContext _context;

        public AmenityRepository(AsyncInnDBContext context)
        {
            _context = context;
        }

        public async Task<Amenity> Create(Amenity amenity)
        {
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Added;

            await _context.SaveChangesAsync();

            return amenity;
        }

        public async Task DeleteAmenity(int ID)
        {
            Amenity amenity = await GetAmenity(ID);
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            var amenities = await _context.Amenities.ToListAsync();

            return amenities;
        }

        public async Task<Amenity> GetAmenity(int ID)
        {
            Amenity amenity = await _context.Amenities.FindAsync(ID);
            var roomAmenities = await _context.RoomAmenities.Where(x => x.AmenityID == ID)
                                                                                    .Include(x => x.Room)
                                                                                    .ToListAsync();

            amenity.RoomAmenities = roomAmenities;
            return amenity;
        }

        public async Task<Amenity> UpdateAmenity(int ID, Amenity amenity)
        {
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
