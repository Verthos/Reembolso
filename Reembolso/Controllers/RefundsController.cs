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
        [Authorize]
        public ActionResult<IEnumerable<Refund>> GetRefunds()
        {

            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            try
            {
                if (identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value == "admin")
                {
                    return Ok(_db.GetAll());
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

        // GET : api/Refunds/2
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Refund> GetRefund(int id)
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            try
            {
                _ = int.TryParse(identity.Claims.FirstOrDefault(c => c.Type == "UserId").Value, out int ownerId);
                Refund refund = _db.GetFirstOrDefault(r => r.Id == id);


                if (_userDb.IsOwnerOrAdmin(identity, refund.OwnerId))
                {
                    return Ok(refund);
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

        // POST : api/Refunds
        [HttpPost]
        [Authorize]
        public ActionResult<Refund> CreateRefund(Refund refund)
        {

            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            _ = int.TryParse(identity.Claims.FirstOrDefault(c => c.Type == "UserId").Value, out int ownerId);

            if (identity == null)
            {
                return Unauthorized("Não autorizado. Entre em contato com um administrador");
            }
            try
            {
                foreach (Item item in refund.Items)
                {
                    item.ParendRefund = refund;
                    item.ParentUserId = ownerId;
                }

                refund.TotalValue = refund.CalculateTotalValue(refund.Items);
                refund.Owner = _userDb.GetFirstOrDefault(o => o.Id == ownerId);
                refund.CreationDate = DateTime.Now;


                _db.Add(refund);
                _db.Save();
                return Created("Reembolso criado", refund.Id);
            } catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} contate um administrador");
            }
            
        }


        // PUT : api/Refunds/2
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Refund> UpdateRefund(Refund refund)
        {
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                if (_userDb.IsOwnerOrAdmin(identity, refund.OwnerId))
                {
                    _db.Update(refund);
                    _db.Save();
                    return Ok($"Reembolso id: {refund.Id} atualizado.");
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

        // DELETE : api/Refunds/2
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<Refund> DeleteRefund(Refund refund)
        {

            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                if (_userDb.IsOwnerOrAdmin(identity, refund.OwnerId))
                {
                    _db.Remove(_db.GetFirstOrDefault(r => r.Id == refund.Id));
                    _db.Save();
                    return Ok($"Reembolso id: {refund.Id} removido");
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


        // PUT: api/Refund/authorize/2
        [HttpPut("authorize/{id}")]
        [Authorize]
        public ActionResult<Refund> AuthorizeRefund(int id)
        {
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                if (_userDb.IsDepartmentManagerOrAdmin(identity))
                {
                    _db.AuthorizeRefund(id);
                    _db.Save();
                    return Ok($"Reembolso id: {id} autorizado");
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

        // PUT: api/Refund/review/2
        [HttpPut("review/{id}")]
        [Authorize]
        public ActionResult<Refund> SendRefundToReview(int id)
        {

            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                if (_userDb.IsDepartmentManagerOrAdmin(identity))
                {
                    _db.SendRefundToReview(id);
                    _db.Save();
                    return Ok($"Reembolso id: {id} enviado para revisão");
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

        // PUT: api/Refund/deny/2
        [HttpPut("deny/{id}")]
        [Authorize]
        public ActionResult<Refund> DenyRefund(int id)
        {
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                if (_userDb.IsDepartmentManagerOrAdmin(identity))
                {
                    _db.DenyRefund(id);
                    _db.Save();
                    return Ok($"Reembolso id: {id} reprovado");
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
        // PUT: api/Refund/deny/2
        [HttpPut("payment/{id}")]
        [Authorize]
        public ActionResult<Refund> SendRefundToPayment(int id)
        {
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                if (_userDb.IsDirectorOrAdmin(identity))
                {
                    _db.SendRefundToPayment(id);
                    _db.Save();
                    return Ok($"Reembolso id: {id} enviado para pagamento");
                }
                else
                {
                    return Unauthorized("Não autorizado. Entre em contato com um administrador");
                }
            }catch( Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
