using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;

namespace Database.Collections
{
    public class UserCollection : IUserCollection
    {
        private readonly IMongoCollection<User> _userCollection;
        private readonly string key;

        public UserCollection(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("MongoDb:ConnectionString");
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            var client = new MongoClient(settings);
            var dbName = configuration.GetValue<string>("MongoDb:Database");
            var database = client.GetDatabase(dbName);
            var userCollectionName = configuration.GetValue<string>("MongoDb: UserCollection");
            this.key = configuration.GetSection("JwtKey").ToString();

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

        public string Authenticate(string email, string password)
        {
            var cursor = _userCollection.Find(x => x.Email == email && x.Password == password);
            var user = cursor.FirstOrDefault();
            
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}