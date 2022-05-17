using CQRSDemo.Models;
using CQRSDemo.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.Handler
{
    public class ParkingCommandHandler
    {
        private readonly DbContext _context;
        private readonly CommandStoreService _commandStoreService;
        private readonly AuthenticationService _authenticationService;

        public ParkingCommandHandler(DbContext context, CommandStoreService commandStoreService, AuthenticationService authenticationService)
        {
            _context = context;
            _commandStoreService = commandStoreService;
            _authenticationService = authenticationService;
        }

        public void Handle(CloseParkingCommand command)
        {
            var parking = _context.Set<Parking>()
                .FirstOrDefault(p => p.Name == command.ParkingName);

            if (parking == null)
            {
                throw new Exception($"Cannot find parking '{command.ParkingName}'.");
            }
            if (!parking.IsOpened)
            {
                throw new Exception($"Parking '{command.ParkingName}' is already closed.");
            }

            parking.IsOpened = false;
            _context.SaveChanges();

            _commandStoreService.Push(command);
        }

        public void Handle(CreateParkingCommand command)
        {
            var places = Enumerable.Range(1, command.Capacity)
                .Select(n =>
                {
                    return new ParkingPlace
                    {
                        ParkingName = command.ParkingName,
                        Number = n,
                        IsFree = true
                    };
                })
                .ToList();

            var parking = new Parking
            {
                Name = command.ParkingName,
                IsOpened = true,
                Places = places
            };

            _context.Add(parking);
            _context.SaveChanges();

            _commandStoreService.Push(command);
        }

        public void Handle(LeaveParkingPlaceCommand command)
        {
            var parking = _context.Set<Models.Parking>()
                .FirstOrDefault(p => p.Name == command.ParkingName);

            if (parking == null)
            {
                throw new Exception($"Cannot find parking '{command.ParkingName}'.");
            }
            if (!parking.IsOpened)
            {
                throw new Exception($"The parking '{command.ParkingName}' is closed.");
            }

            //var parkingPlace = _context.Set<ParkingPlace>()
            //    .FirstOrDefault(p => p.ParkingName == command.ParkingName && p.Number = command.PlaceNumber);

            var parkingPlace = _context.Set<ParkingPlace>()
                .FirstOrDefault(p => p.ParkingName == command.ParkingName && p.Number == command.PlaceNumber);

            if (parkingPlace == null)
            {
                throw new Exception($"Cannot find place #{command.PlaceNumber} in the parking '{command.ParkingName}'.");
            }
            if (parkingPlace.IsFree)
            {
                throw new Exception($"Parking place #{command.PlaceNumber} is still free.");
            }

            parkingPlace.IsFree = true;
            parkingPlace.UserId = null;
            _context.SaveChanges();

            _commandStoreService.Push(command);
        }

        public void Handle(OpenParkingCommand command)
        {
            var parking = _context.Set<Models.Parking>()
                .FirstOrDefault(p => p.Name == command.ParkingName);

            if (parking == null)
            {
                throw new Exception($"Cannot find parking '{command.ParkingName}'.");
            }
            if (parking.IsOpened)
            {
                throw new Exception($"Parking '{command.ParkingName}' is already opened.");
            }

            parking.IsOpened = true;
            _context.SaveChanges();

            _commandStoreService.Push(command);
        }

        public void Handle(TakeParkingPlaceCommand command)
        {
            var parking = _context.Set<Models.Parking>()
                .FirstOrDefault(p => p.Name == command.ParkingName);

            if (parking == null)
            {
                throw new Exception($"Cannot find parking '{command.ParkingName}'.");
            }
            if (!parking.IsOpened)
            {
                throw new Exception($"The parking '{command.ParkingName}' is closed.");
            }

            var parkingPlace = _context.Set<ParkingPlace>()
                .FirstOrDefault(p => p.ParkingName == command.ParkingName && p.Number == command.PlaceNumber);

            if (parkingPlace == null)
            {
                throw new Exception($"Cannot find place #{command.PlaceNumber} in the parking '{command.ParkingName}'.");
            }
            if (!parkingPlace.IsFree)
            {
                throw new Exception($"Parking place #{command.PlaceNumber} is already taken.");
            }

            parkingPlace.IsFree = false;
            parkingPlace.UserId = _authenticationService.GetUserId();
            _context.SaveChanges();

            _commandStoreService.Push(command);
        }
    }
}

        

