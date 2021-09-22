using System.Threading.Tasks;
using ApiWrapper.ReloadlyClient;
using ApiWrapper.ReloadlyClient.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReloadlyController : Controller
    {
        private readonly IReloadlyClient _reloadlyClient;

        public ReloadlyController(IReloadlyClient reloadlyClient)
        {
            _reloadlyClient = reloadlyClient;
        }
        // POST
        [HttpPost("GetToken")]
        public async Task<ActionResult<Response<GetAccessTokenResponse>>> GetAccessTokenAsync()
        {
            var response = await _reloadlyClient.GetAccessTokenAsync();
            return StatusCode(response.StatusCode, response);
        }
        // GET
        [HttpGet("view-balance")]
        public async Task<ActionResult<Response<ViewBalanceResponse>>> ViewBalnceAsync()
        {
            var response = await _reloadlyClient.ViewBalanceAsync();
            return StatusCode(response.StatusCode, response);
        }

    }
}