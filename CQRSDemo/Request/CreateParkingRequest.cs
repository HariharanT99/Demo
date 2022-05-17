using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSDemo.Request
{
    public class CreateParkingRequest
    {
        public string ParkingName { get; set; }
        public int Capacity { get; set; }
    }
}
