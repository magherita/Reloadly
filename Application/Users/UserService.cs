using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Models.Donations;
using Database.Collections;
using Domain.User;

namespace Application.Users
{
    public class UserService : IUserService
    {
        private readonly UserCollection _userCollection;

        public UserService(UserCollection userCollection)
        {
            _userCollection = userCollection;
        }
        public async Task<List<GetUserModel>> GetUsers(CancellationToken cancellationToken = default)
        {
            var results = await _userCollection.GetAll(cancellationToken);
            if (results == null || results.Count < 1)
            {
                return new List<GetUserModel>();
            }

            var response = new List<GetUserModel>();
            foreach (var result in results)
            {
                var model = new GetUserModel()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Email = result.Email,
                    UserName = result.UserName  
                };

                response.Add(model);
            }
            return response;
        }

        public async Task<GetUserModel> GetUserById(string userId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new Exception("User Id is empty");
            }

            var result =  await _userCollection.GetUserById(userId, cancellationToken);

            if (result == null)
            {
                return new GetUserModel();
            }

            var response = new GetUserModel
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                UserName = result.UserName
            };
            return response;
        }

        public async Task<GetUserModel> CreateUser(AddUserModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new Exception("User details are empty");
            }

            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName
            };
            var result = await _userCollection.CreateUser(user, cancellationToken);
            var response = new GetUserModel()
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                UserName = result.UserName
            };
            return response;
        }

        public void UpdateUser(string userId, UpdateUserModel model)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new Exception("User Id is empty");
            }
            if (model == null)
            {
                throw new Exception("User Id is empty");
            }
            var currentWallet = _userCollection.GetUserById(userId).Result;

            if (currentWallet == null)
            {
                throw new Exception("Book does not exist");
            }

            currentWallet.FirstName = model.FirstName;
            currentWallet.LastName = model.LastName;
            currentWallet.Email = model.Email;
            currentWallet.PhoneNumber = model.PhoneNumber;
            
            _userCollection.UpdateUser(userId, currentWallet);
        }

        public void DeleteUserById(DeleteUserModel model)
        {
            if (model == null)
            {
                throw new Exception("User Id is empty");
            }

            _userCollection.DeleteUserById(model.Id);
        }
    }
}