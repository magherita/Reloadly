using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Donation
{
    public interface IDonationCollection
    {
        Task<Donation> CreateDonation(Donation donation, CancellationToken cancellationToken = default); 
        Task<List<Donation>> GetAll(CancellationToken cancellationToken = default);
    }
}