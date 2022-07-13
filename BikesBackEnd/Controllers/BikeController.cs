using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BikesBackEnd.Models;
using BikesBackEnd.Services;

namespace BikesBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BikeController : Controller
    {
        private readonly BikeServices _bikeservice;
        private readonly StationServices _stationService;
        public BikeController(BikeServices bikeServices, StationServices stationService)
        {
            _bikeservice = bikeServices;
            _stationService = stationService;
        }

        [HttpGet]
        [Route("GetBikes")]
        public List<Bike> GetBikes()
        {
            List<Bike> bikes = _bikeservice.getBikes();

            return bikes;
        }
        
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("AddABike")]
        public IActionResult CreatedBike([FromBody] Bike bikeform)
        {
            Bike bike = new Bike()
            {
                Id = Guid.NewGuid(),
                Type = bikeform.Type,
                IsWorking = bikeform.IsWorking,
                LockOn = bikeform.LockOn,
                IdStation = new Guid("d7472677-0752-4378-9341-b22615491faf")
            };
            _bikeservice.addBike(bike);
            return Ok("Bici aggiunta!");
        }
        
        //[Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("RemoveBike/{id}")]
        public IActionResult DeletedBike(Guid id)
        {
            _bikeservice.DeleteBike(id);
            return Ok("Bici eliminata");
        }
        //[Authorize(Roles = "Admin")]
        [HttpPatch]
        [Route("LockUnlock/{id}")]
        public IActionResult LockUnlock(Guid id)
        {
            _bikeservice.PatchLock(id);
            return Ok(_bikeservice.findBikebyId(id).LockOn);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPatch]
        [Route("RunningorNot/{id}")]
        public IActionResult RunOrNotRun(Guid id)
        {
            _bikeservice.PatchWorking(id);
            return Ok(_bikeservice.findBikebyId(id).LockOn);
        }

    }
}
