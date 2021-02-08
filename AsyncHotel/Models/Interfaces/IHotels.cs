using AsyncHotel.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.Interfaces
{
    public interface IHotels
    {
        Task<Hotels> Create(Hotels hotel);
        Task<HotelsDTO> GetHotel(int ID);
        Task<List<HotelsDTO>> GetHotels();
        Task<Hotels> UpdateHotel(int ID, Hotels hotel);
        Task DeleteHotel(int ID);
    }
}
