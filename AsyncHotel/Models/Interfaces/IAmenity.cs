using AsyncHotel.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.Interfaces
{
    public interface IAmenity
    {

        Task<Amenity> Create(AmenityDTO amenity);
        Task<AmenityDTO> GetAmenity(int ID);
        Task<List<AmenityDTO>> GetAmenities();
        Task<Amenity> UpdateAmenity(int ID, Amenity amenity);
        Task DeleteAmenity(int ID);
    }
}
