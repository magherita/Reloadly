using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Models.Wallets;
using Domain.Wallet;

namespace Application.Wallets
{
    public class WalletService : IWalletService
    {
        private readonly IWalletCollection _walletCollection;

        public WalletService(IWalletCollection walletCollection)
        {
            _walletCollection = walletCollection;
        }
        public async Task<List<GetWalletModel>> GetWallets(CancellationToken cancellationToken = default)
        {
            var results = await _walletCollection.GetAll(cancellationToken);
            if (results == null || results.Count < 1)
            {
                return new List<GetWalletModel>();
            }

            var response = new List<GetWalletModel>();
            foreach (var result in results)
            {
                var model = new GetWalletModel()
                {
                    
                };

                response.Add(model);
            }
            return response;
        }

        public async Task<GetWalletModel> GetWalletById(string walletId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(walletId))
            {
                throw new Exception("Wallet Id is empty");
            }

            var result = _walletCollection.GetWalletById(walletId, cancellationToken);
            
            if (result == null)
            {
                return new GetWalletModel();
            }

            var response = new GetWalletModel()
            {

            };
            return response;
        }

        public async Task<GetWalletModel> CreateWallet(AddWalletModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new Exception("Wallet details are empty");
            }

            var wallet = new Wallet()
            {

            };
            var result = await _walletCollection.CreateWallet(wallet, cancellationToken);
            var response = new GetWalletModel()
            {
                Id = model.Id
            };
            return response;

        }

        public void UpdateWallet(string walletId, UpdateWalletModel model)
        {
            if (string.IsNullOrWhiteSpace(walletId))
            {
                throw new Exception("Wallet Id is empty");
            }
            if (model == null)
            {
                throw new Exception("Wallet Id is empty");
            }
            var currentWallet = _walletCollection.GetWalletById(walletId).Result;

            if (currentWallet == null)
            {
                throw new Exception("Book does not exist");
            }

            currentWallet.Id = model.Id;
            _walletCollection.UpdateWallet(walletId, currentWallet);
        }

        public void DeleteWalletById(DeleteWalletModel model)
        {
            if (model == null)
            {
                throw new Exception("Wallet Id is empty");
            }

            _walletCollection.DeleteWalletById(model.Id);
        }
    }
}