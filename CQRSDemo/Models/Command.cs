using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSDemo.Models
{
    public class Command
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
    }
}
