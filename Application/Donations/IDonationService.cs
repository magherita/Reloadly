using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Models.Donations;

namespace Application.Donations
{
    public interface IDonationService
    {
        
        Task<List<GetDonationsModel>> GetDonations(CancellationToken cancellationToken = default);

        Task<GetDonationsModel> GetDonationById(string donationId, CancellationToken cancellationToken = default);

        Task<GetDonationsModel> CreateDonation(AddDonationModel model, CancellationToken cancellationToken = default);

        void UpdateDonation(string donationId, UpdateDonationModel model);

        void DeleteDonationById(DeleteDonationModel model);
    }
}