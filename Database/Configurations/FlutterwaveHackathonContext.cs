using Domain.Donation;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Database.Configurations
{
    public class FlutterwaveHackathonContext : DbContext, IFlutterwaveHackathonContext
    {
       
        public FlutterwaveHackathonContext(DbContextOptions<FlutterwaveHackathonContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Donation> Donations { get; set; }
    }
}