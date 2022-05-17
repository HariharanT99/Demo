using CQRSDemo.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSDemo.Services
{
    public class CommandStoreService
    {
        private readonly DbContext _context;
        private readonly AuthenticationService _authenticationService;

        public CommandStoreService(DbContext context, AuthenticationService authenticationService)
        {
            _context = context;
            _authenticationService = authenticationService;
        }

        public void Push(object command)
        {
            _context.Set<Command>().Add(
                new Command
                {
                    Type = command.GetType().Name,
                    Data = JsonConvert.SerializeObject(command),
                    CreatedAt = DateTime.Now,
                    UserId = _authenticationService.GetUserId()
                }
            );
            _context.SaveChanges();
        }
    }
}
