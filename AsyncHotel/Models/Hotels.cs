﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models
{
    public class Hotels
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string PhoneNumber { get; set; }

        //Navigation Properties:
        public List<HotelRoom> hotelRooms { get; set; }

    }
}
