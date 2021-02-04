using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models
{
    public class HotelRoom
    {
        public int HotelsID { get; set; }
        public int RoomNumber { get; set; }
        public int RoomID { get; set; }
        public float Rate { get; set; }
        public bool PetFriendly { get; set; }

        //Navigation Properties:
        public Hotels Hotels { get; set; }
        public Room Room { get; set; }

    }
}
