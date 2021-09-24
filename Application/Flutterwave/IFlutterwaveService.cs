using ApiWrapper.FlutterwaveClient.Requests;
using ApiWrapper.FlutterwaveClient.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Flutterwave
{
    public interface IFlutterwaveService
    {
        Task<ChargeCardResponse> DeductPaymentAsync(
            ChargeCardRequest request,
            CancellationToken cancellationToken = default);
    }
}
