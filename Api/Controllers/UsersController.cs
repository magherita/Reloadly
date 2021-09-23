using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Models.Users;
using Application.Users;
using Domain.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

       private readonly IUserService _userService;
       private readonly IUserCollection _userCollection;

       public UsersController(IUserService userService, IUserCollection userCollection)
       {
           _userService = userService;
           _userCollection = userCollection;
       }
       // GET: api/Wallets
       [HttpGet]
       [HttpGet]
       public async Task<ActionResult<List<GetUserModel>>> GetAsync()
       {
           var response = await _userService.GetUsers();

           return Ok(response);
       }
       // GET: api/Wallets/5
       [HttpGet("{id}")]
       public async Task<ActionResult<GetUserModel>> GetUserByIdAsync([FromRoute] string id)
       {
           var response = await _userService.GetUserById(id);

           return Ok(response);
       }
       // POST: api/Wallets
       [HttpPost]
       public async Task<ActionResult<GetUserModel>> PostAsync([FromBody] AddUserModel model)
       {
           var response = await _userService.CreateUser(model);

           return Ok(response);
       }

       // PUT: api/Wallets/5
       [HttpPut("{id}")]
       public IActionResult Put([FromRoute] string id, [FromBody] UpdateUserModel model)
       {
           _userService.UpdateUser(id, model);

           return NoContent();
       }

       // DELETE: api/Wallets/5
       [HttpDelete("{id}")]
       public IActionResult Delete([FromRoute] string id)
       {
           _userService.DeleteUserById(new DeleteUserModel() { Id = id });

           return NoContent();
       }
       
    }
}
