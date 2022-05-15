#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MtgDataAPI.Data;
using Reembolso.Models;
using Reembolso.Repository.IRepository;

namespace Reembolso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _db;

        public ItemsController(IItemsRepository db)
        {
            _db = db;
        }
        // GET: api/Items
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            IEnumerable<Item> items = _db.GetAll();
            return Ok(items);
        }
        // GET: api/Items/2
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(int id)
        {
            return Ok(_db.GetFirstOrDefault(e => e.Id == id));
        }

        // POST: api/Items
        [HttpPost]
        public ActionResult<Item> PostItem(Item item)
        {
            _db.Add(item);
            _db.Save();
            return Created("Item adicionado", item);
        }

        // PUT: api/Item/2
        [HttpPut("{id}")]
        public ActionResult<Item> UpdateItem(Item item)
        {
            _db.Update(item);
            _db.Save();
            return Ok($"Item id: {item.Id} atualizado.");
        }

        // DELETE: api/Item/2
        [HttpDelete("{id}")]
        public ActionResult<Item> DeleteItem(int Id)
        {
            Item item = _db.GetFirstOrDefault(e => e.Id==Id);
            _db.Remove(item);
            _db.Save();

            return Ok($"Item id: {item.Id} removido com sucesso.");
        }

    }
}
