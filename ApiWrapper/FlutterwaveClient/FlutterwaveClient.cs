using ApiWrapper.FlutterwaveClient.Requests;
using ApiWrapper.FlutterwaveClient.Responses;
using Flurl.Http;
using Newtonsoft.Json;
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
            var stringRequest = JsonConvert.SerializeObject(request);

            var encryptedRequest = stringRequest.Encrypt("API Encryption Key From Flutterwave");

            // send to flutterwave
            var result = await "https://api.flutterwave.com"
                .AllowAnyHttpStatus()
                .AppendPathSegment("v3/charges?type=card")
                .PostJsonAsync(
                new
                {
                    client = encryptedRequest
                });

            if (result.StatusCode >= 300)
            {
               // do something with the error

                return null;//return response with error
            }

            var data = await result.GetJsonAsync<ChargeCardResponse>();

            return data;
        }
    }
}