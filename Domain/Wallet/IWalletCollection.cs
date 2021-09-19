using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Wallet
{
    public interface IWalletCollection
    {
        
        Task<List<Wallet>> GetAll (CancellationToken cancellationToken = default);
        Task<Wallet> GetWalletById (string walletId, CancellationToken cancellationToken = default);
        Task<Wallet> CreateWallet (Wallet wallet, CancellationToken cancellationToken = default);
        void UpdateWallet (string walletId, Wallet wallet);
        void DeleteWalletById (string walletId);
    }
}