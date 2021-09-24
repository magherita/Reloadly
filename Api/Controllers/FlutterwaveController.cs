using ApiWrapper.FlutterwaveClient.Requests;
using ApiWrapper.FlutterwaveClient.Responses;
using Application.Flutterwave;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlutterwaveController : ControllerBase
    {
        private readonly IFlutterwaveService _flutterwaveService;

        public FlutterwaveController(IFlutterwaveService flutterwaveService)
        {
            _flutterwaveService = flutterwaveService;
        }

        [HttpPost("charge-card")]
        public async Task<ActionResult<ChargeCardResponse>> ChargeCardAsync([FromBody] ChargeCardRequest request)
        {
            var response = await _flutterwaveService.DeductPaymentAsync(request);

            return Ok(response);
        }
    }
}
