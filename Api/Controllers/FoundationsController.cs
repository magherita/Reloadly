using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Foundations;
using Application.Models.Foundations;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoundationsController : Controller
    {
        private readonly IFoundationService _foundationService;

        
       
               public FoundationsController(IFoundationService foundationService)
               {
                   _foundationService = foundationService;
               }
               
               // GET: api/Foundations
               
               [HttpGet]
               public async Task<ActionResult<List<GetFoundationsModel>>> GetAsync()
               {
                   var response = await _foundationService.GetFoundations();
       
                   return Ok(response);
               }
               
               // GET: api/Foundations/5
               [HttpGet("{id}")]
               public async Task<ActionResult<GetFoundationsModel>> GetFoundationByIdAsync([FromRoute] string id)
               {
                   var response = await _foundationService.GetFoundationById(id);
       
                   return Ok(response);
               }
               
               // POST: api/Wallets
               [HttpPost]
               public async Task<ActionResult<GetFoundationsModel>> PostAsync([FromBody] AddFoundationModel model)
               {
                   var response = await _foundationService.CreateFoundation(model);
       
                   return Ok(response);
               }
       
               // PUT: api/Wallets/5
               [HttpPut("{id}")]
               public IActionResult Put([FromRoute] string id, [FromBody] UpdateFoundationModel model)
               {
                   _foundationService.UpdateFoundation(id, model);
       
                   return NoContent();
               }
       
               // DELETE: api/Wallets/5
               [HttpDelete("{id}")]
               public IActionResult Delete([FromRoute] string id)
               {
                   _foundationService.DeleteFoundationById(new DeleteFoundationModel() { Id = id });
       
                   return NoContent();
               }
    }
}