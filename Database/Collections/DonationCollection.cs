using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Donation;
using Domain.Foundation;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Database.Collections
{
    public class DonationCollection : IDonationCollection
    {
        private readonly IMongoCollection<Donation> _donationCollection;

        public DonationCollection(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("MongoDb:ConnectionString");
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            var client = new MongoClient(settings);
            var dbName = configuration.GetValue<string>("MongoDb:Database");
            var database = client.GetDatabase(dbName);
            var donationCollectionName = configuration.GetValue<string>("MongoDb:DonationCollection");

            _donationCollection = database.GetCollection<Donation>(donationCollectionName);
        }

        public async Task<Donation> CreateDonation(Donation donation, CancellationToken cancellationToken = default)
        {
            await _donationCollection.InsertOneAsync(donation);
            return donation;
        }

        public async Task<List<Donation>> GetAll(CancellationToken cancellationToken = default)
        {
            var cursor = await _donationCollection.FindAsync(d => true);
            var donations = await cursor.ToListAsync();
            return donations;
        }
    }
}