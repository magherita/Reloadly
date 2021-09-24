using ApiWrapper.FlutterwaveClient.Requests;
using ApiWrapper.FlutterwaveClient.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace ApiWrapper.FlutterwaveClient
{
    public class FlutterwaveClient : IFlutterwaveClient
    {
        public FlutterwaveClient()
        {

        }

        public async Task<ChargeCardResponse> ChargeCardAsync(
            ChargeCardRequest request, 
            CancellationToken cancellationToken = default)
        {
            // encrypt it using 3DES

            // send to flutterwave

            return null;
        }
    }
}