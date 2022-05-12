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
    public class RefundsController : ControllerBase
    {
        private readonly IRefundRepository _db;

        public RefundsController(IRefundRepository db)
        {
            _db = db;
        }
        
        // GET : api/Refounds
        [HttpGet]
        public ActionResult<IEnumerable<Refund>> GetRefunds()
        {
            return Ok(_db.GetAll());
        }

        // GET : api/Refunds/2
        [HttpGet("{id}")]
        public ActionResult<Refund> GetRefund(int id)
        {
            return Ok(_db.GetFirstOrDefault(r => r.Id == id));
        }

        // POST : api/Refunds
        [HttpPost]
        public ActionResult<Refund> CreateRefund(Refund refund)
        {
            _db.Add(refund);
            _db.Save();
            return CreatedAtAction("Reembolso criado", refund);
        }

        // PUT : api/Refunds/2
        [HttpPut("{id}")]
        public ActionResult<Refund> UpdateRefund(Refund refund)
        {
            _db.Update(refund);
            return Ok($"Reembolso id: {refund.Id} atualizado.");
        }

        // DELETE : api/Refunds/2
        [HttpDelete("{id}")]
        public ActionResult<Refund> DeleteRefund(int id)
        {
            _db.Remove(_db.GetFirstOrDefault(r => r.Id == id));
            return Ok($"Reembolso id: {id}removido");
        }
    }

}
