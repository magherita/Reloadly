using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Models.Donations;

namespace Application.Users
{
    public interface IUserService
    {
        
        Task<List<GetUserModel>> GetUsers(CancellationToken cancellationToken = default);

        Task<GetUserModel> GetUserById(string userId, CancellationToken cancellationToken = default);

        Task<GetUserModel> CreateUser(AddUserModel model, CancellationToken cancellationToken = default);

        void UpdateUser(string walletId, UpdateUserModel model);

        void DeleteUserById(DeleteUserModel model);
    }
}