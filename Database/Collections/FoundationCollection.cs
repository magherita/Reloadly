using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Foundation;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Database.Collections
{
    public class FoundationCollection : IFoundationCollection
    {
        private readonly IMongoCollection<Foundation> _foundationCollection;
        public FoundationCollection(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("MongoDb:ConnectionString");
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            var client = new MongoClient(settings);
            var dbName = configuration.GetValue<string>("MongoDb:Database");
            var database = client.GetDatabase(dbName);
            var foundationCollectionName = configuration.GetValue<string>("MongoDb:FoundationCollection");

            _foundationCollection = database.GetCollection<Foundation>(foundationCollectionName);

        }
        public async Task<List<Foundation>> GetAll(CancellationToken cancellationToken = default)
        {
            var cursor = await _foundationCollection.FindAsync(d => true);
            var foundations = await cursor.ToListAsync();
            return foundations;
        }

        public async Task<Foundation> GetFoundationById(string foundationId, CancellationToken cancellationToken = default)
        {
            var cursor = await _foundationCollection.FindAsync(d => d.Id == foundationId);
            var foundation = await cursor.FirstOrDefaultAsync(cancellationToken);
            return foundation;
        }

        public async Task<Foundation> CreateFoundation(Foundation foundation, CancellationToken cancellationToken = default)
        {
            await _foundationCollection.InsertOneAsync(foundation);
            return foundation;
        }

        public void UpdateFoundation(string foundationId, Foundation foundation)
        {
            _foundationCollection.ReplaceOne(d => d.Id == foundationId, foundation);

        }

        public void DeleteFoundationById(string foundationId)
        {
            _foundationCollection.DeleteOne(d => d.Id == foundationId);
        }
    }
}