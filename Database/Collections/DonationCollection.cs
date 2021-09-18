using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Donation;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Database.Collections
{
    public class DonationCollection : IDonationCollection
    {
        private IMongoCollection<Donation> _donationsCollection;
        public DonationCollection(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("MongoDb:ConnectionString");
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            var client = new MongoClient(settings);
            var dbName = configuration.GetValue<string>("MongoDb:Database");
            var database = client.GetDatabase(dbName);
            var donationCollectionName = configuration.GetValue<string>("MongoDB: DonationsCollection");

            _donationsCollection = database.GetCollection<Donation>(donationCollectionName);

        }
        public async Task<List<Donation>> GetAll(CancellationToken cancellationToken = default)
        {
            var cursor = await _donationsCollection.FindAsync(d => true);
            var donations = await cursor.ToListAsync();
            return donations;
        }

        public async Task<Donation> GetDonationById(string donationId, CancellationToken cancellationToken = default)
        {
            var cursor = await _donationsCollection.FindAsync(d => d.Id == donationId);
            var donation = await cursor.FirstOrDefaultAsync(cancellationToken);
            return donation;
        }

        public async Task<Donation> CreateDonation(Donation donation, CancellationToken cancellationToken = default)
        {
            await _donationsCollection.InsertOneAsync(donation);
            return donation;
        }

        public void UpdateDonation(string donationId, Donation donation)
        {
            _donationsCollection.ReplaceOne(d => d.Id == donationId, donation);

        }

        public void DeleteDonationById(string donationId)
        {
            _donationsCollection.DeleteOne(d => d.Id == donationId);
        }
    }
}