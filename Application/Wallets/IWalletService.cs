// using System.Collections.Generic;
// using System.Threading;
// using System.Threading.Tasks;
// using Application.Models.Wallets;
//
// namespace Application.Wallets
// {
//     public interface IWalletService
//     {
//         Task<List<GetWalletModel>> GetWallets(CancellationToken cancellationToken = default);
//
//         Task<GetWalletModel> GetWalletById(string walletId, CancellationToken cancellationToken = default);
//
//         Task<GetWalletModel> CreateWallet(AddWalletModel model, CancellationToken cancellationToken = default);
//
//         void UpdateWallet(string walletId, UpdateWalletModel model);
//
//         void DeleteWalletById(DeleteWalletModel model);
//     }
// }