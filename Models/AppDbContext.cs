using Microsoft.EntityFrameworkCore;
using Models.DBModels;  

namespace Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<DBBookedRide> BookedRides { get; set; }
        public DbSet<DBOfferRide> OfferRides { get; set; }
        public DbSet<DBUser> Users{ get; set; }
    }
}
