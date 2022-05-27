using Refunds.Core.Entities;
using Refunds.Core.Interfaces.Repositories;

namespace Refunds.Infrastructure.Persistence.Repositories
{
    public class RefundRepository : Repository<Refund>, IRefundRepository
    {
        private readonly ReembolsoContext _db;
        public RefundRepository(ReembolsoContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
        public void Update(Refund refund)
        {
            _db.Update(refund);
        }

        // 1: Pendente, 2: Aprovado, 3: Revisão do usuário, 4: Reprovado, 5: Enviado para pagamento; 
        public void AuthorizeRefund(int id)
        {
            Refund? refund = _db.Refunds.FirstOrDefault(r => r.Id == id);
            if (refund != null)
            {
                refund.AprovingId = 2;
                refund.ClosingDate = DateTime.Now;
                _db.Update(refund);
            }
            else
            {
                throw new KeyNotFoundException($"Id {id} não encontrado");
            }
        }

        public void SendRefundToReview(int id)
        {
            Refund? refund = _db.Refunds.FirstOrDefault(r => r.Id == id);
            if (refund != null)
            {
                refund.AprovingId = 3;
                _db.Update(refund);
            }
            else
            {
                throw new KeyNotFoundException($"Id {id} não encontrado");
            }
        }

        public void DenyRefund(int id)
        {
            Refund? refund = _db.Refunds.FirstOrDefault(r => r.Id == id);

            if (refund != null)
            {
                refund.AprovingId = 4;
                refund.ClosingDate = DateTime.Now;
                _db.Update(refund);
            }
            else
            {
                throw new KeyNotFoundException($"Id {id} não encontrado");
            }

        }


        public void SendRefundToPayment(int id)
        {
            Refund? refund = _db.Refunds.FirstOrDefault(r => r.Id == id);

            if (refund != null)
            {
                refund.AprovingId = 5;
                refund.ClosingDate = DateTime.Now;
                _db.Update(refund);
            }
            else
            {
                throw new KeyNotFoundException($"Id {id} não encontrado");
            }
        }
    }
}
