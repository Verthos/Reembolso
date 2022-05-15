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
        private readonly IUserRepository _userDb;

        public RefundsController(IRefundRepository db, IUserRepository userDb)
        {
            _db = db;
            _userDb = userDb;
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
        public ActionResult<Refund> CreateRefund(Refund refund,int ownerId)
        {
            foreach (Item item in refund.Items)
            {
                item.ParendRefund = refund;
            }

            refund.TotalValue = refund.CalculateTotalValue(refund.Items);
            refund.Owner = _userDb.GetFirstOrDefault(o => o.Id == ownerId);
            refund.CreationDate = DateTime.Now;


            _db.Add(refund);
            _db.Save();
            return Created("Reembolso criado", refund.Id);
        }

        // PUT : api/Refunds/2
        [HttpPut("{id}")]
        public ActionResult<Refund> UpdateRefund(Refund refund)
        {
            _db.Update(refund);
            _db.Save();
            return Ok($"Reembolso id: {refund.Id} atualizado.");
        }

        // DELETE : api/Refunds/2
        [HttpDelete("{id}")]
        public ActionResult<Refund> DeleteRefund(int id)
        {
            _db.Remove(_db.GetFirstOrDefault(r => r.Id == id));
            _db.Save();
            return Ok($"Reembolso id: {id} removido");
        }





        // PUT: api/Refund/authorize/2
        [HttpPut("authorize/{id}")]
        public ActionResult<Refund> AuthorizeRefund(int id)
        {
            _db.AuthorizeRefund(id);
            _db.Save();
            return Ok($"Reembolso id: {id} autorizado");
        }

        // PUT: api/Refund/review/2
        [HttpPut("review/{id}")]
        public ActionResult<Refund> SendRefundToReview(int id)
        {
            _db.SendRefundToReview(id);
            _db.Save();
            return Ok($"Reembolso id: {id} enviado para revisão");
        }

        // PUT: api/Refund/deny/2
        [HttpPut("deny/{id}")]
        public ActionResult<Refund> DenyRefund(int id)
        {
            _db.DenyRefund(id);
            _db.Save();
            return Ok($"Reembolso id: {id} reprovado");
        }

    }

}
