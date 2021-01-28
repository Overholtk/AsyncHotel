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
    public class BedroomsController : ControllerBase
    {
        private readonly IRoom _room;

        public BedroomsController(IRoom room)
        {
            _room = room;
        }

        // GET: api/Bedrooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return Ok(await _room.GetRooms());
        }

        // GET: api/Bedrooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _room.GetRoom(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Bedrooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBedroom(int id, Room room)
        {
            if(id != room.ID)
            {
                return BadRequest();
            }

            var updatedRoom = await _room.UpdateRoom(id, room);
            return Ok(updatedRoom);
        }

        // POST: api/Bedrooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Room>> PostBedroom(Room room)
        {
            await _room.Create(room);
            return CreatedAtAction("GetRoom", new { id = room.ID }, room);
        }

        // DELETE: api/Bedrooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteBedroom(int id)
        {
            await _room.Delete(id);
            return NoContent();
        }

    }
}
