using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSDemo.Commands
{
    public class CloseParkingCommand
    {
        public string ParkingName { get; set; }
    }
}
