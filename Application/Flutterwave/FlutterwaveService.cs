using ApiWrapper;
using ApiWrapper.FlutterwaveClient.Requests;
using ApiWrapper.FlutterwaveClient.Responses;
using Domain.Donation;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Flutterwave
{
    public class FlutterwaveService : IFlutterwaveService
    {
        private readonly IFlutterwaveClient _flutterwaveClient;
        private readonly IDonationCollection _donationCollection;

        public FlutterwaveService(
            IFlutterwaveClient flutterwaveClient,
            IDonationCollection donationCollection)
        {
            _flutterwaveClient = flutterwaveClient;
            _donationCollection = donationCollection;
        }

        public async Task<ChargeCardResponse> DeductPaymentAsync(
            ChargeCardRequest request, 
            CancellationToken cancellationToken = default)
        {
            var response = await _flutterwaveClient.ChargeCardAsync(request);

            // save to database
            // plus other work to be done 
            await _donationCollection.CreateDonation(new Donation 
            {
                Amount = request.Amount,
                Email = request.Email,
                FirstName = request.Fullname
            });

            return response;
        }
    }
}
