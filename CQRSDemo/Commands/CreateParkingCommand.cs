using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSDemo.Commands
{
    public class CreateParkingCommand
    {
        public string ParkingName { get; set; }
        public int Capacity { get; set; }
    }
}
