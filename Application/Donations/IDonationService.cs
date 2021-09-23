using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Models.Wallets;

namespace Application.Wallets
{
    public interface IDonationService
    {
        Task<GetDonationModel> CreateDonation (AddDonationModel model, CancellationToken cancellationToken = default);
        Task<List<GetDonationModel>> GetDonations(CancellationToken cancellationToken = default);
    }
}