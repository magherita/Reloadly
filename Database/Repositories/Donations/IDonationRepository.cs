using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Donation;

namespace Database.Repositories.Donations
{
    public interface IDonationRepository
    {
        Task CreateDonationAsync(Donation donation, CancellationToken cancellationToken = default);
        Task<Donation> RetrieveDonationAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Donation>> RetrieveDonationsAsync(CancellationToken cancellationToken = default);
        void UpdateDonation(Donation donation);
        void DeleteDonation(Donation donation);
    }
}