
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Refunds.Core.Entities;
using Refunds.Core.Interfaces.Auth;
using Refunds.Core.Interfaces.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Refunds.Application.Auth
{
    public class Auth : IAuth<User>
    {
        private readonly IUserRepository _users;
        private readonly IConfiguration _config;
        private readonly IPasswordHasher<User> _hasher;
        public Auth(IConfiguration config, IUserRepository users, IPasswordHasher<User> hasher)
        {
            _hasher = hasher;
            _users = users;
            _config = config;
        }


        public User AuthenticateUser(string user, string password)
        {
            User currentUser = _users.GetFirstOrDefault(u => u.login == user);
            PasswordVerificationResult passwordVerificationResult = _hasher.VerifyHashedPassword(currentUser, currentUser.Password, password);

            if (passwordVerificationResult == PasswordVerificationResult.Success)
            {
                return currentUser;
            }
            else
            {
                throw new Exception("Usuário ou senha incorretos.");
            };
        }

        public string GenerateToken(User user)
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
