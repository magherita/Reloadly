using ReloadlyHttpClient.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace ReloadlyHttpClient
{
    public interface IReloadlyClient
    {
        Task<Response<GetAccessTokenResponse>> GetAccessTokenAsync(CancellationToken token = default);

        Task<Response<ViewBalanceResponse>> ViewBalanceAsync(CancellationToken token = default);
    }
}
