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

        /// <summary>
        /// sets context to the database
        /// </summary>
        /// <param name="context"></param>
        public AmenityRepository(AsyncInnDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// creates an amenity
        /// </summary>
        /// <param name="inboundData">inputted DTO data</param>
        /// <returns>the created amenity</returns>
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

        /// <summary>
        /// deletes an amenity
        /// </summary>
        /// <param name="ID">ID value of the amenity to be deleted</param>
        /// <returns></returns>
        public async Task DeleteAmenity(int ID)
         {
            AmenityDTO amenitydto = await GetAmenity(ID);
            Amenity amenity = await _context.Amenities.FirstOrDefaultAsync(x => x.ID == amenitydto.ID);
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
         }

        /// <summary>
        /// get all amenities
        /// </summary>
        /// <returns>a list of amenity DTOs</returns>
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

        /// <summary>
        /// get one amenity
        /// </summary>
        /// <param name="ID">the ID of the amenity to return</param>
        /// <returns>amenity DTO</returns>
        public async Task<AmenityDTO> GetAmenity(int ID)
        {
            return await _context.Amenities
                .Select(amenity => new AmenityDTO
                {
                    ID = amenity.ID,
                    Name = amenity.Name
                }).FirstOrDefaultAsync(a => a.ID == ID);
        }

        /// <summary>
        /// update a specific amenity
        /// </summary>
        /// <param name="ID">the ID of the amenity to be updated</param>
        /// <param name="amenity">new amenity data</param>
        /// <returns>newly created amenity</returns>
        public async Task<Amenity> UpdateAmenity(int ID, Amenity amenity)
        {
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
