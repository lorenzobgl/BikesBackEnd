using Microsoft.EntityFrameworkCore;

namespace BikesBackEnd.Data
{
    public class AppDbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
