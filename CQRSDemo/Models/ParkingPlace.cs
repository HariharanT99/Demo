using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSDemo.Models
{
    public class ParkingPlace
    {
        public string ParkingName { get; set; }
        public int Number { get; set; }
        public bool IsFree { get; set; }
        public string UserId { get; set; }
        public Parking Parking { get; set; }
    }
}
