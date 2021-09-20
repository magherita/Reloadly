using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Donations;
using Application.Models.Donations;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationsController : Controller
    {
        
               private readonly IDonationService _donationService;
       
               public DonationsController(IDonationService donationService)
               {
                   _donationService = donationService;
               }
               // GET: api/Wallets
               [HttpGet]
               [HttpGet]
               public async Task<ActionResult<List<GetDonationsModel>>> GetAsync()
               {
                   var response = await _donationService.GetDonations();
       
                   return Ok(response);
               }
               // GET: api/Wallets/5
               [HttpGet("{id}")]
               public async Task<ActionResult<GetDonationsModel>> GetDonationByIdAsync([FromRoute] string id)
               {
                   var response = await _donationService.GetDonationById(id);
       
                   return Ok(response);
               }
               // POST: api/Wallets
               [HttpPost]
               public async Task<ActionResult<GetDonationsModel>> PostAsync([FromBody] AddDonationModel model)
               {
                   var response = await _donationService.CreateDonation(model);
       
                   return Ok(response);
               }
       
               // PUT: api/Wallets/5
               [HttpPut("{id}")]
               public IActionResult Put([FromRoute] string id, [FromBody] UpdateDonationModel model)
               {
                   _donationService.UpdateDonation(id, model);
       
                   return NoContent();
               }
       
               // DELETE: api/Wallets/5
               [HttpDelete("{id}")]
               public IActionResult Delete([FromRoute] string id)
               {
                   _donationService.DeleteDonationById(new DeleteDonationModel() { Id = id });
       
                   return NoContent();
               }
    }
}