using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Models.Wallets;
using Application.Wallets;
using Domain.Donation;

namespace Application.Donations
{
    public class DonationService : IDonationService
    {
        private readonly IDonationCollection _donationCollection;


        public DonationService(IDonationCollection donationCollection)
        {
            _donationCollection = donationCollection;
        }
        public async Task<List<GetDonationModel>> GetDonations (CancellationToken cancellationToken = default)
        {
            var results = await _donationCollection.GetAll(cancellationToken);
            if (results == null || results.Count < 1)
            {
                return new List<GetDonationModel>();
            }

            var response = new List<GetDonationModel>();
            foreach (var result in results)
            {
                var model = new GetDonationModel()
                {
                 Id   = result.Id,
                 Email = result.Email,
                 FirstName = result.FirstName,
                 LastName = result.LastName,
                 Location = result.Location,
                 Amount = result.Amount,
                };

                response.Add(model);
            }
            return response;
        }


        public async Task<GetDonationModel> CreateDonation(AddDonationModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new Exception("Wallet details are empty");
            }

            var donation = new Donation()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Location = model.Location,
                Amount = model.Amount,
            };
            var result = await _donationCollection.CreateDonation(donation, cancellationToken);
            var response = new GetDonationModel()
            {
                Id   = result.Id,
                Email = result.Email,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Location = result.Location,
                Amount = result.Amount,
            };
            return response;
        }
        
    }
    
}