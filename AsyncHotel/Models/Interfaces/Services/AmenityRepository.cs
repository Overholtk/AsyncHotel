using AsyncHotel.Data;
using AsyncHotel.Models.API;
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

        public async Task<Amenity> Create(AmenityDTO inboundData)
        {
            Amenity amenity = new Amenity()
            {
                ID = inboundData.ID,
                Name = inboundData.Name
            };

            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return amenity;
        }

        public async Task DeleteAmenity(int ID)
         {
            AmenityDTO amenitydto = await GetAmenity(ID);
            Amenity amenity = await _context.Amenities.FirstOrDefaultAsync(x => x.ID == amenitydto.ID);
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
         }

        public async Task<List<AmenityDTO>> GetAmenities()
        {
            var amenities = await _context.Amenities
                .Select(amenity => new AmenityDTO
                {
                    ID = amenity.ID,
                    Name = amenity.Name
                })
                .ToListAsync();

            return amenities;
        }

        public async Task<AmenityDTO> GetAmenity(int ID)
        {
            return await _context.Amenities
                .Select(amenity => new AmenityDTO
                {
                    ID = amenity.ID,
                    Name = amenity.Name
                }).FirstOrDefaultAsync(a => a.ID == ID);
        }

        public async Task<Amenity> UpdateAmenity(int ID, Amenity amenity)
        {
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
