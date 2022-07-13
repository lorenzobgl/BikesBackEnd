using BikesBackEnd.Models;
using BikesBackEnd.Data;

namespace BikesBackEnd.Services
{
    public class BikeServices
    {
        public readonly AppDbContext _appDbContext;
        public readonly StationService _stationService;
        public BikeServices(AppDbContext appDbContext, StationService stationService)
        {
            _appDbContext = appDbContext;
            _stationService = stationService;
        }

        public void addBike(Bike bike)
        {
            _appDbContext.Bikes.Add(bike);
            _appDbContext.SaveChanges();
        }
        public void ChangeStatus(Bike bike)
        {
            bike.IsWorking = false;
            _appDbContext.SaveChanges();
        }
        public List<Bike> getBikes()
        {
            List<Bike> Bikes = _appDbContext.Bikes.ToList();
            return Bikes;
        }
        public Bike findBikebyId(Guid Id)
        {
            return _appDbContext.Bikes.FirstOrDefault(b => b.Id == Id);
        }
        public void PatchLock(Guid Id)
        {
            Bike b = findBikebyId(Id);
            b.LockOn = !b.LockOn;
            _appDbContext.Bikes.Update(b);
            _appDbContext.SaveChanges();
        }
        public void PatchWorking(Guid Id)
        {
            Bike b = findBikebyId(Id);
            b.IsWorking = !b.IsWorking;
            _appDbContext.Bikes.Update(b);
            _appDbContext.SaveChanges();
        }
        public void PatchStation(Guid IdBike,Guid IdStation)
        {
            var bike = findBikebyId(IdBike);
            var station = _stationService.getStationbyId(IdStation);
            bike.Station = station;
            _appDbContext.Update(bike);
            _appDbContext.SaveChanges();
        }
        public void DeleteBike(Guid Id)
        {
            Bike b=findBikebyId(Id);
            _appDbContext.Bikes.Remove(b);
            _appDbContext.SaveChanges();
        }

    }
}
