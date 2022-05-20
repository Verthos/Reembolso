using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IUserRepository _users;
        private IConfiguration _config;
        public AuthController(IConfiguration config, IUserRepository users)
        {
            _users = users;
            _config = config;
        }





        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate(string userName, string mail)
        {
            var user = AuthenticateUser(userName, mail);
            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(token);
            }
            return NotFound("User not found");
        }

        private User AuthenticateUser(string user, string password)
        {
            User currentUser = _users.GetFirstOrDefault(u => u.Name == user && u.Email == password);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Name.ToLower()),
                new Claim(ClaimTypes.Role, user.Department),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt.Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
