using BikesBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BikesBackEnd.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Bike> Bikes { get; set; }
        public virtual DbSet<BikeStation> BikeStations { get; set; }
    }
}
