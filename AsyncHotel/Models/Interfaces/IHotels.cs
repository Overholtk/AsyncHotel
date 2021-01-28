using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.Interfaces
{
    public interface IHotels
    {
        Task<Hotels> Create(Hotels hotel);
        Task<Hotels> GetHotel(int ID);
        Task<List<Hotels>> GetHotels();
        Task<Hotels> UpdateHotel(int ID, Hotels hotel);
        Task DeleteHotel(int ID);
    }
}
