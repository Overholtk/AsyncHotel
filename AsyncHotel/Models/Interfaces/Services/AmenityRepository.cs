using AsyncHotel.Data;
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
        public Task<Amenity> Create(Amenity amenity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAmenity(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Amenity>> GetAmenities()
        {
            throw new NotImplementedException();
        }

        public Task<Amenity> GetAmenity(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<Amenity> UpdateAmenity(int ID, Amenity amenity)
        {
            throw new NotImplementedException();
        }
    }
}
