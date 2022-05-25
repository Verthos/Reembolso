#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reembolso.Models;
using Reembolso.Repository.IRepository;

namespace Reembolso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _db;
        private readonly IUserRepository _userDb;

        public ItemsController(IItemsRepository db, IUserRepository userDb)
        {
            _userDb = userDb;
            _db = db;
        }

        // GET: api/Items
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            try
            {
                if (_userDb.IsDirectorOrAdmin(identity))
                {
                    IEnumerable<Item> items = _db.GetAll();
                    return Ok(items);
                }
                else
                {
                    return Unauthorized("Não autorizado. Entre em contato com um administrador");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Item/2
        [HttpPut("{id}")]
        public ActionResult<Item> UpdateItem(Item item)
        {
            try
            {
                _db.Update(item);
                _db.Save();
                return Ok($"Item id: {item.Id} atualizado.");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // DELETE: api/Item/2
        [HttpDelete("{id}")]
        public ActionResult<Item> DeleteItem(int Id)
        {
            try
            {
                Item item = _db.GetFirstOrDefault(e => e.Id==Id);
                _db.Remove(item);
                _db.Save();
                return Ok($"Item id: {item.Id} removido com sucesso.");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
