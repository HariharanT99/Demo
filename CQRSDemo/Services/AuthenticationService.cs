using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSDemo.Services
{
    public class AuthenticationService
    {
        private readonly string _userId;
        public AuthenticationService()
        {
            _userId = Guid.NewGuid().ToString();
        }

        public string GetUserId() => _userId;
    }
}
