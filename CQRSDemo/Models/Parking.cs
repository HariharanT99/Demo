using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSDemo.Models
{
    public class Parking
    {
        public string Name { get; set; }
        public bool IsOpened { get; set; }

        public List<ParkingPlace> Places { get; set; }
    }
}
