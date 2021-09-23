using Application.Users;
using Database.Collections;
using Domain.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserCollection _userCollection;

        public LoginController(IUserCollection  userCollection)
        {
            _userCollection = userCollection;
        }
        
        // Authentication
        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public ActionResult Login([FromBody] User user)
        {
            var token = _userCollection.Authenticate(user.Email, user.Password);
            if (token == null)
                return Unauthorized();
            return Ok(new { token, user });
        }
    }
}