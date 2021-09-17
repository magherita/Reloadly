using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Database.Repositories.Users;
using Domain.User;

namespace Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
            
        }
        public Task CreateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<User> RetrieveUserAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> RetrieveUserAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}