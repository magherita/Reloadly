using ApiWrapper.FlutterwaveClient.Requests;
using ApiWrapper.FlutterwaveClient.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace ApiWrapper
{
    public interface IFlutterwaveClient
    {
        Task<ChargeCardResponse> ChargeCardAsync(
            ChargeCardRequest request,
            CancellationToken cancellationToken = default);
    }
}