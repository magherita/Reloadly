using System.Threading;
using System.Threading.Tasks;
using ApiWrapper.ReloadlyClient.Responses;

namespace ApiWrapper.ReloadlyClient
{
    public interface IReloadlyClient
    {
        Task<Response<GetAccessTokenResponse>> GetAccessTokenAsync(CancellationToken cancellationToken = default);
    }
}