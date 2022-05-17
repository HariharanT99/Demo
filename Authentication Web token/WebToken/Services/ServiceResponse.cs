using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebToken.Services
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
