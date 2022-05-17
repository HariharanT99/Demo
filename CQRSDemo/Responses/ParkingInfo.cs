using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSDemo.Responses
{
    public class ParkingInfo
    {
        public string Name { get; set; }
        public bool IsOpened { get; set; }
        public int MaximumPlaces { get; set; }
        public int AvailablePlaces { get; set; }
    }
}
