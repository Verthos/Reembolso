using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reembolso.Auth;
using Reembolso.Models;
using Reembolso.Repository.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
