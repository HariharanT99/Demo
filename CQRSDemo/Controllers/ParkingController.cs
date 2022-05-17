﻿using CQRSDemo.Commands;
using CQRSDemo.Commands.Handler;
using CQRSDemo.Queries;
using CQRSDemo.Queries.Handlers;
using CQRSDemo.Request;
using CQRSDemo.Responses;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly ParkingCommandHandler _commandHandler;
        private readonly ParkingQueryHandler _queryHandler;

        public ParkingController(ParkingCommandHandler commandHandler, ParkingQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        [HttpGet("availablePlaces/count")]
        public int GetTotalAvailablePlaces()
        {
            var query = new GetTotalAvailablePlace();
            return _queryHandler.Handle(query);
        }

        [HttpGet("availablePlaces/random")]
        public ParkingPlaceInfo GetRandomAvailablePlace()
        {
            var query = new GetRandomAvailablePlace();
            return _queryHandler.Handle(query);
        }

        [HttpGet]
        public IEnumerable<ParkingInfo> GetAllParkingInfos()
        {
            var query = new GetAllParkingInfoQuery();
            return _queryHandler.Handle(query);
        }

        [HttpGet("{parkingName}")]
        public ParkingInfo GetParkingInfo(string parkingName)
        {
            var query = new GetParkingInfoQuery { ParkingName = parkingName };
            return _queryHandler.Handle(query);
        }

        [HttpPost]
        public void CreateParking([FromBody] CreateParkingRequest request)
        {
            var command = request.Adapt<CreateParkingCommand>();
            _commandHandler.Handle(command);
        }

        [HttpPost("{parkingName}/open")]
        public void OpenParking(string parkingName)
        {
            var command = new OpenParkingCommand { ParkingName = parkingName };
            _commandHandler.Handle(command);
        }


        [HttpPost("{parkingName}/close")]
        public void CloseParking(string parkingName)
        {
            var command = new CloseParkingCommand { ParkingName = parkingName };
            _commandHandler.Handle(command);
        }

        [HttpPost("{parkingName}/{placeNumber}/take")]
        public void TakeParkingPlace(string parkingName, int placeNumber)
        {
            var command = new TakeParkingPlaceCommand
            {
                ParkingName = parkingName,
                PlaceNumber = placeNumber
            };
            _commandHandler.Handle(command);
        }

        [HttpPost("{parkingName}/{placeNumber}/leave")]
        public void LeaveParkingPlace(string parkingName, int placeNumber)
        {
            var command = new LeaveParkingPlaceCommand
            {
                ParkingName = parkingName,
                PlaceNumber = placeNumber
            };
            _commandHandler.Handle(command);
        }

    }
}
