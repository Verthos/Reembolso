using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private IPasswordHasher<User> _hasher;
        public AuthController(IConfiguration config, IUserRepository users, IPasswordHasher<User> hasher)
        {
            _hasher = hasher;
            _users = users;
            _config = config;
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate(string userName, string userPassword)
        {
            var user = AuthenticateUser(userName, userPassword);
            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(token);
            }
            return NotFound("Usuário ou senha incorretos.");
        }


        private User AuthenticateUser(string user, string password)
        {
            User currentUser = _users.GetFirstOrDefault(u => u.Name == user);
            PasswordVerificationResult passwordVerificationResult = _hasher.VerifyHashedPassword(currentUser, currentUser.Password, password);
            
            if (passwordVerificationResult == PasswordVerificationResult.Success)
            {
                return currentUser;
            }
            return null;
        }



        private string GenerateToken(User user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            string role = user.IsAdmin ? "admin" : user.IsDirector ? "director" : user.IsManager ? "manager" : "user";
            
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Name.ToLower()),
                new Claim(ClaimTypes.Role, role),
                new Claim("UserId", user.Id.ToString()),
                //new Claim("Department", user.Department.Name)
            };



            JwtSecurityToken token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt.Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
