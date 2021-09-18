using Domain.Donation;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Database.Configurations
{
    public interface IFlutterwaveHackathonContext
    {
        public DbSet<User> Users { get; set; }
        public  DbSet<Donation> Donations { get; set; }
    }
}