using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncHotel.Data;
using AsyncHotel.Models;
using AsyncHotel.Models.Interfaces;

namespace AsyncHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotels _hotel;

        public HotelsController(IHotels hotel)
        {
            _hotel = hotel;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotels>>> GetHotels()
        {
            return Ok(await _hotel.GetHotels());
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotels>> GetHotels(int id)
        {
            var hotels = await _hotel.GetHotel(id);

            if (hotels == null)
            {
                return NotFound();
            }

            return hotels;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotels(int id, Hotels hotels)
        {
            if(id != hotels.ID)
            {
                return BadRequest();
            }

            var updatedHotel = await _hotel.UpdateHotel(id, hotels);
            return Ok(updatedHotel);
        }

        // POST: api/Hotels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Hotels>> PostHotels(Hotels hotels)
        {
            await _hotel.Create(hotels);
            return CreatedAtAction("GetHotels", new { id = hotels.ID }, hotels);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotels>> DeleteHotels(int id)
        {
            await _hotel.DeleteHotel(id);
            return NoContent();
        }
    }
}
