using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Database.Configurations;
using Domain.Donation;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Donations
{
    public class DonationRepository : IDonationRepository
    {
        private readonly FlutterwaveHackathonContext _context;

        public DonationRepository(FlutterwaveHackathonContext context)
        {
            _context = context;
        }
        public async Task CreateDonationAsync(Donation donation, CancellationToken cancellationToken = default)
        {
            await _context.Donations.AddAsync(donation);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Donation> RetrieveDonationAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Donations.Where(d => d.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Donation>> RetrieveDonationsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Donations.ToListAsync(cancellationToken);
        }

        public void UpdateDonation(Donation donation)
        {
            _context.Donations.Update(donation);
            _context.SaveChanges();
        }

        public void DeleteDonation(Donation donation)
        {
            _context.Donations.Remove(donation);
            _context.SaveChanges();
        }
    }
}