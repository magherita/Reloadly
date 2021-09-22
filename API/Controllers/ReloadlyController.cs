using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReloadlyHttpClient;
using ReloadlyHttpClient.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReloadlyController : ControllerBase
    {
        private readonly IReloadlyClient _reloadlyClient;

        public ReloadlyController(IReloadlyClient reloadlyClient)
        {
            _reloadlyClient = reloadlyClient;
        }

        //[HttpPost("access-token")]
        //public async Task<ActionResult<Response<GetAccessTokenResponse>>> GetAccessTokenAsync()
        //{
        //    var response = await _reloadlyClient.GetAccessTokenAsync();

        //    return StatusCode(response.StatusCode, response);
        //}

        [HttpGet("view-balance")]
        public async Task<ActionResult<Response<ViewBalanceResponse>>> ViewBalanceAsync()
        {
            var response = await _reloadlyClient.ViewBalanceAsync();

            return StatusCode(response.StatusCode, response);
        }
    }
}
