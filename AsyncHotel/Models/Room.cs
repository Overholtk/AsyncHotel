using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models
{
    public class Room
    {
        public int ID { get; set; }

        [Required]
        public string Nickname { get; set; }

        public int Layout { get; set; }

        //Navigation Properties:
        public List<RoomAmenities> RoomAmenities { get; set; }

    }
}
