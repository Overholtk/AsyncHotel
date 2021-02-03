using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models
{
    public class RoomAmenities
    {
        public int AmenityID { get; set; }
        public int RoomID { get; set; }

        //Navigation Properties
        public Amenity Amenity { get; set; }
        public Room Room { get; set; }
    }
}
