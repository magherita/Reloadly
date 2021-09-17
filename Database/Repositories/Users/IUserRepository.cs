using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.User;

namespace Database.Repositories.Users
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user, CancellationToken cancellationToken = default);
        Task<User> RetrieveUserAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<User>> RetrieveUserAsync(CancellationToken cancellationToken = default);
        void UpdateUser (User user);
        void DeleteUser (User user);
    }
}