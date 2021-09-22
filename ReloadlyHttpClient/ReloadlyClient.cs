using Flurl.Http;
using Microsoft.Extensions.Configuration;
using ReloadlyHttpClient.Requests;
using ReloadlyHttpClient.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace ReloadlyHttpClient
{
    public class ReloadlyClient : IReloadlyClient
    {
        private readonly IConfiguration _configuration;
        private Response<GetAccessTokenResponse> _accessTokenResponse;

        public ReloadlyClient(IConfiguration configuration)
        {
            _configuration = configuration;
            _accessTokenResponse = GetAccessTokenAsync().Result;
        }

        public async Task<Response<GetAccessTokenResponse>> GetAccessTokenAsync(CancellationToken token = default)
        {
            var request = new GetAccessTokenRequest
            {
                Client_Id = _configuration.GetValue<string>("Reloadly:ClientId"),
                Client_Secret = _configuration.GetValue<string>("Reloadly:ClientSecret"),
                Grant_Type = _configuration.GetValue<string>("Reloadly:GrantType"),
                Audience = _configuration.GetValue<string>("Reloadly:Audience")
            };

            var authUrl = _configuration.GetValue<string>("Reloadly:AuthUrl");

            var result = await authUrl
                .AllowAnyHttpStatus()
                .AppendPathSegment(Endpoints.GetAccessToken)
                .PostJsonAsync(
                new
                {
                    client_id = request.Client_Id,
                    client_secret = request.Client_Secret,
                    grant_type = request.Grant_Type,
                    audience = request.Audience
                });

            if (result.StatusCode >= 300)
            {
                var error = await result.GetJsonAsync<ErrorResponse>();

                return new Response<GetAccessTokenResponse> 
                { 
                    StatusCode =  result.StatusCode,
                    Error = error 
                };
            }

            var data = await result.GetJsonAsync<GetAccessTokenResponse>();

            return new Response<GetAccessTokenResponse> 
            {
                StatusCode = result.StatusCode,
                Data = data 
            };
        }

        public async Task<Response<ViewBalanceResponse>> ViewBalanceAsync(CancellationToken token = default)
        {
            if (_accessTokenResponse.Error != null)
            {
                return new Response<ViewBalanceResponse>
                {
                    StatusCode = _accessTokenResponse.StatusCode,
                    Error = _accessTokenResponse.Error
                };
            }

            var accessToken = _accessTokenResponse.Data.Access_Token;
            var baseUrl = _configuration.GetValue<string>("Reloadly:BaseUrl");

            var result = await baseUrl
                .AllowAnyHttpStatus()
                .WithOAuthBearerToken(accessToken)
                .AppendPathSegment(Endpoints.ViewBalance)
                .GetAsync();

            if (result.StatusCode >= 300)
            {
                var error = await result.GetJsonAsync<ErrorResponse>();

                return new Response<ViewBalanceResponse>
                {
                    StatusCode = result.StatusCode,
                    Error = error
                };
            }

            var data = await result.GetJsonAsync<ViewBalanceResponse>();

            return new Response<ViewBalanceResponse>
            {
                StatusCode = result.StatusCode,
                Data = data
            };
        }
    }
}
