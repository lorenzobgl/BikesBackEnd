using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BikesBackEnd.Models;
using BikesBackEnd.Services;

namespace BikesBackEnd.Controllers
{
    public class BikeController : Controller
    {
        private readonly BikeServices _bikeservice;
        private readonly StationService _stationService;
        public BikeController(BikeServices bikeServices, StationService stationService)
        {
            _bikeservice = bikeServices;
            _stationService = stationService;
        }
        [HttpGet(Name = "GetBikes")]
        public List<Bike> GetBikes()
        {
            List<Bike> bikes = _bikeservice.getBikes();

            return bikes;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet(Name = "AddBike")]
        public IActionResult CreatedBike([FromBody] Bike bikeform)
        {
            Bike bike = new Bike()
            {
                Id = Guid.NewGuid(),
                Type = bikeform.Type,
                IsWorking = bikeform.IsWorking,
                LockOn = bikeform.LockOn,
                IdStation = new Guid("d70552c0-6185-4c78-88c0-f56272678bc9")
            };
            _bikeservice.addBike(bike);
            return Ok("Bici aggiunta");
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete(Name = "RemoveBike")]
        public IActionResult DeletedBike([FromBody] Guid id)
        {
            _bikeservice.DeleteBike(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch(Name = "LockUnlock")]
        public IActionResult LockUnlock([FromBody] Guid id)
        {
            _bikeservice.PatchLock(id);
            return RedirectToAction("Index");
        }
    }
}
