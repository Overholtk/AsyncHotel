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
    public class HotelRoomsController : ControllerBase
    {

        private readonly IHotelRoom _hotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }

        // GET: api/HotelRooms
        [HttpGet("{HotelID}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms(int HotelID)
        {
            return Ok(await _hotelRoom.GetHotelRooms(HotelID));
        }

        // GET: api/HotelRooms/5
        [HttpGet("{HotelID}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int HotelID, int roomNumber)
        {
            var hotelRoom = await _hotelRoom.GetHotelRoom(HotelID, roomNumber);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{HotelID}/Room/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int HotelID, int roomNumber, HotelRoom hotelRoom)
        {
            if (HotelID != hotelRoom.HotelsID || roomNumber != hotelRoom.RoomNumber)
            {
                return BadRequest();
            }

            var updatedHotelRoom = await _hotelRoom.UpdateHotelRoom(HotelID, roomNumber, hotelRoom);
            return Ok(updatedHotelRoom);
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{HotelID}/Rooms/{roomID}")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(int HotelID, int roomID)
        {
            await _hotelRoom.Create(HotelID, roomID);
            return NoContent();
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{HotelID}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int HotelID, int roomNumber)
        {
            await _hotelRoom.Delete(HotelID, roomNumber);
            return NoContent();
        }
    }
}
