using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Database.Configurations;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly FlutterwaveHackathonContext _context;

        public UserRepository(FlutterwaveHackathonContext context)
        {
            _context = context;
        }
        public async Task CreateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<User> RetrieveUserAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Users.Where(d => d.Id == id).FirstOrDefaultAsync(cancellationToken);

        }

        public async Task<List<User>> RetrieveUserAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Users.ToListAsync(cancellationToken);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}