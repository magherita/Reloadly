using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.User;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Database.Collections
{
    public class UserCollection : IUserCollection
    {
        private IMongoCollection<User> _userCollection;

        public UserCollection(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("MongoDb:ConnectionString");
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            var client = new MongoClient(settings);
            var dbName = configuration.GetValue<string>("MongoDb:Database");
            var database = client.GetDatabase(dbName);
            var userCollectionName = configuration.GetValue<string>("MongoDB: UserCollection");

            _userCollection = database.GetCollection<User>(userCollectionName);

        }
        public async Task<List<User>> GetAll(CancellationToken cancellationToken = default)
        {
            var cursor = await _userCollection.FindAsync(u => true);
            var user = await cursor.ToListAsync();
            return user;
        }

        public async Task<User> GetUserById(string userId, CancellationToken cancellationToken = default)
        {
            var cursor = await _userCollection.FindAsync(u => u.Id == userId);
            var user = await cursor.FirstOrDefaultAsync(cancellationToken);
            return user;
        }

        public async Task<User> CreateUser(User user, CancellationToken cancellationToken = default)
        {
            await _userCollection.InsertOneAsync(user);
            return user;
        }

        public void UpdateUser(string userId, User user)
        {
            _userCollection.ReplaceOne(u => u.Id == userId, user);
        }

        public void DeleteUserById(string userId)
        {
            _userCollection.DeleteOne(u => u.Id == userId);
        }
    }
}