using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Donation
{
    public interface IDonationCollection
    {
        
        Task<List<Donation>> GetAll(CancellationToken cancellationToken = default);
        Task<Donation> GetDonationById(string donationId, CancellationToken cancellationToken = default);
        Task<Donation> CreateDonation(Donation donation, CancellationToken cancellationToken = default);
        void UpdateDonation(string donationId, Donation donation);
        void DeleteDonationById(string donationId);
    }
}