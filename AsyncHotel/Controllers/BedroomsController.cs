using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncHotel.Data;
using AsyncHotel.Models;

namespace AsyncHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedroomsController : ControllerBase
    {
        private readonly AsyncInnDBContext _context;

        public BedroomsController(AsyncInnDBContext context)
        {
            _context = context;
        }

        // GET: api/Bedrooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetBedrooms()
        {
            return await _context.Bedrooms.ToListAsync();
        }

        // GET: api/Bedrooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetBedroom(int id)
        {
            var bedroom = await _context.Bedrooms.FindAsync(id);

            if (bedroom == null)
            {
                return NotFound();
            }

            return bedroom;
        }

        // PUT: api/Bedrooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBedroom(int id, Room bedroom)
        {
            if (id != bedroom.ID)
            {
                return BadRequest();
            }

            _context.Entry(bedroom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BedroomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bedrooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Room>> PostBedroom(Room bedroom)
        {
            _context.Bedrooms.Add(bedroom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBedroom", new { id = bedroom.ID }, bedroom);
        }

        // DELETE: api/Bedrooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteBedroom(int id)
        {
            var bedroom = await _context.Bedrooms.FindAsync(id);
            if (bedroom == null)
            {
                return NotFound();
            }

            _context.Bedrooms.Remove(bedroom);
            await _context.SaveChangesAsync();

            return bedroom;
        }

        private bool BedroomExists(int id)
        {
            return _context.Bedrooms.Any(e => e.ID == id);
        }
    }
}
