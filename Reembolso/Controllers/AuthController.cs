using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Refunds.Core.Entities;
using Refunds.Infrastructure.Auth;


namespace Reembolso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _auth;
        public AuthController(IAuth auth)
        {
            _auth = auth;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate(string userName, string userPassword)
        {
            try
            {
                User user = _auth.AuthenticateUser(userName, userPassword);
                if (user != null)
                {
                    string token = _auth.GenerateToken(user);
                    return Ok(new { jwt = token, userName = user.Name });
                }

                return NotFound("Usuário ou senha incorretos.");

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
