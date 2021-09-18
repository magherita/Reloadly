using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Wallet;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Database.Collections
{
    public class WalletCollection : IWalletCollection
    {
        private IMongoCollection<Wallet> _walletCollection;

        public WalletCollection(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("MongoDb:ConnectionString");
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            var client = new MongoClient(settings);
            var dbName = configuration.GetValue<string>("MongoDb:Database");
            var database = client.GetDatabase(dbName);
            var walletCollectionName = configuration.GetValue<string>("MongoDB: WalletCollection");

            _walletCollection = database.GetCollection<Wallet>(walletCollectionName);

        }
        public async Task<List<Wallet>> GetAll(CancellationToken cancellationToken = default)
        {
            var cursor = await _walletCollection.FindAsync(w => true);
            var wallets = await cursor.ToListAsync();
            return wallets;
        }

        public async Task<Wallet> GetWalletById(string walletId, CancellationToken cancellationToken = default)
        {
            var cursor = await _walletCollection.FindAsync(w => w.Id == walletId);
            var wallet = await cursor.FirstOrDefaultAsync(cancellationToken);
            return wallet;
        }

        public async  Task<Wallet> CreateWallet(Wallet wallet, CancellationToken cancellationToken = default)
        {
            await _walletCollection.InsertOneAsync(wallet);
            return wallet;
        }

        public void UpdateWallet(string walletId, Wallet wallet)
        {
            _walletCollection.ReplaceOne(w => w.Id == walletId, wallet);
        }

        public void DeleteUserByWallet(string walletId)
        {
            _walletCollection.DeleteOne(w => w.Id == walletId);
        }
    }
}