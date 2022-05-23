#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MtgDataAPI.Data;
using Reembolso.Models;
using Reembolso.Repository.IRepository;

namespace Reembolso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _db;
        private readonly IPasswordHasher<User> _hasher;

        public UsersController(IUserRepository db, IPasswordHasher<User> hasher)
        {
            _hasher = hasher;
            _db = db;
        }

        // GET: api/Users
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value == "admin")
                {
                    IEnumerable<User> users = _db.GetAll();
                    return Ok(users);
                }
                else
                {
                    return Unauthorized("Não autorizado. Entre em contato com um administrador");
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<User> GetUser(int id)
        {
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value == "admin")
                {
                    return Ok(_db.GetFirstOrDefault(u => u.Id == id));
                }
                else
                {
                    return Unauthorized("Não autorizado. Entre em contato com um administrador");
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult PutUser(int id, User user)
        {
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value == "admin")
                {
                    _db.Update(user);
                    _db.Save();
                    return Ok($"User id: {id} updated");
                }
                else
                {
                    return Unauthorized("Não autorizado. Entre em contato com um administrador");
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

            

        }

        // POST: api/Users
        [HttpPost]
        [Authorize]
        public ActionResult<User> CreateUser(User user)
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value == "admin")
            {
                User newUser = user;
                newUser.Password = _hasher.HashPassword(newUser, newUser.Password);
                newUser.login = user.Name[0].ToString().ToLower() + user.LastName.ToLower();
                try
                {
                    _db.Add(newUser);
                    _db.Save();
                    return Created("Usuario criado", new { Message = $"Usuário de nome {user.login} criado" });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return Unauthorized("Não autorizado. Entre em contato com um administrador");
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value == "admin")
                {
                    _db.Remove(_db.GetFirstOrDefault(e => e.Id == id));
                    _db.Save();
                    return Ok($"User id:{id} was deleted");
                }
                else
                {
                    return Unauthorized("Não autorizado. Entre em contato com um administrador");
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
