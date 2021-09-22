using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ApiWrapper.ReloadlyClient.Responses;
using ApiWrapper.Requests;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

namespace ApiWrapper.ReloadlyClient
{
    public class ReloadlyClient : IReloadlyClient
    {
        private readonly IConfiguration _configuration;

        public ReloadlyClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Response<GetAccessTokenResponse>> GetAccessTokenAsync(CancellationToken cancellationToken = default)
        {
            var request = new GetAccessTokenRequest()
            {
                Client_Id = _configuration.GetValue<string>("Reloadly:ClientId"),
                Client_Secret = _configuration.GetValue<string>("Reloadly:ClientSecret"),
                Grant_Type = _configuration.GetValue<string>("Reloadly:GrantType"),
                Audience = _configuration.GetValue<string>("Reloadly:Audience"),
            };

            var authUrl = _configuration.GetValue<string>("Reloadly:AuthUrl");

            var result = await authUrl.AllowHttpStatus().AppendPathSegment(EndPoints.GetAccessToken).PostJsonAsync(
                new
                {
                    client_Id = request.Client_Id,
                    client_secret = request.Client_Secret,
                    grant_type = request.Grant_Type,
                    audience = request.Audience
                });
            if (result.StatusCode >= 300)
            {
                var error = await result.GetJsonAsync<ErrorResponse>();

                return new Response<GetAccessTokenResponse>()
                {
                    StatusCode = result.StatusCode,
                    Error = error
                };
            }

            var data = await result.GetJsonAsync<GetAccessTokenResponse>();
            return new Response<GetAccessTokenResponse>()
            {
                StatusCode = result.StatusCode,
                Data = data
            };
        }
    }
}