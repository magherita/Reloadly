// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Application.Models.Wallets;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Api.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class WalletsController : ControllerBase
//     {
//         private readonly IWalletService _walletService;
//
//         public WalletsController(IWalletService walletService)
//         {
//             _walletService = walletService;
//         }
//         // GET: api/Wallets
//         [HttpGet]
//         [HttpGet]
//         public async Task<ActionResult<List<GetWalletModel>>> GetAsync()
//         {
//             var response = await _walletService.GetWallets();
//
//             return Ok(response);
//         }
//         // GET: api/Wallets/5
//         [HttpGet("{id}")]
//         public async Task<ActionResult<GetWalletModel>> GetWalletByIdAsync([FromRoute] string id)
//         {
//             var response = await _walletService.GetWalletById(id);
//
//             return Ok(response);
//         }
//         // POST: api/Wallets
//         [HttpPost]
//         public async Task<ActionResult<GetWalletModel>> PostAsync([FromBody] AddWalletModel model)
//         {
//             var response = await _walletService.CreateWallet(model);
//
//             return Ok(response);
//         }
//
//         // PUT: api/Wallets/5
//         [HttpPut("{id}")]
//         public IActionResult Put([FromRoute] string id, [FromBody] UpdateWalletModel model)
//         {
//             _walletService.UpdateWallet(id, model);
//
//             return NoContent();
//         }
//
//         // DELETE: api/Wallets/5
//         [HttpDelete("{id}")]
//         public IActionResult Delete([FromRoute] string id)
//         {
//             _walletService.DeleteWalletById(new DeleteWalletModel() { Id = id });
//
//             return NoContent();
//         }
//     }
// }
