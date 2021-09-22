using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Models.Donations;
using Domain.Foundation;

namespace Application.Donations
{
    public class DonationService : IDonationService
    {
        private readonly IDonationCollection _donationCollection;

        public DonationService(IDonationCollection donationCollection)
        {
            _donationCollection = donationCollection;
        }
        public async Task<List<GetDonationsModel>> GetDonations(CancellationToken cancellationToken = default)
        {
            var results = await _donationCollection.GetAll(cancellationToken);
            if (results == null || results.Count < 1)
            {
                return new List<GetDonationsModel>();
            }

            var response = new List<GetDonationsModel>();
            foreach (var result in results)
            {
                var model = new GetDonationsModel()
                {
                    Id = result.Id,
                    Amount = result.Amount,
                    UserId = result.UserId
                };

                response.Add(model);
            }
            return response;
        }

        public async Task<GetDonationsModel> GetDonationById(string donationId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(donationId))
            {
                throw new Exception("Donation Id is empty");
            }

            var result = await _donationCollection.GetDonationById(donationId, cancellationToken);
            
            if (result == null)
            {
                return new GetDonationsModel();
            }

            var response = new GetDonationsModel()
            {
                Id = result.Id,
                Amount = result.Amount,
                UserId = result.UserId
            };
            return response;
        }

        public async Task<GetDonationsModel> CreateDonation(AddDonationModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new Exception("Donation details are empty");
            }

            var donation = new Donation()
            {
                Amount = model.Amount,
                UserId = model.UserId
            };
            var result = await _donationCollection.CreateDonation(donation, cancellationToken);
            var response = new GetDonationsModel()
            {
                Id = result.Id,
                Amount = result.Amount,
                UserId = result.UserId
            };
            return response;
        }

        public void UpdateDonation(string donationId, UpdateDonationModel model)
        {
            if (string.IsNullOrWhiteSpace(donationId))
            {
                throw new Exception("Donation Id is empty");
            }
            if (model == null)
            {
                throw new Exception("Donation Id is empty");
            }
            var currentDonation = _donationCollection.GetDonationById(donationId).Result;

            if (currentDonation == null)
            {
                throw new Exception("Book does not exist");
            }
            
            currentDonation.Amount = model.Amount;
            currentDonation.UserId = model.UserId;
            _donationCollection.UpdateDonation(donationId, currentDonation);
        }

        public void DeleteDonationById(DeleteDonationModel model)
        {
            if (model == null)
            {
                throw new Exception("Donation Id is empty");
            }

            _donationCollection.DeleteDonationById(model.Id);
        }
    }
}