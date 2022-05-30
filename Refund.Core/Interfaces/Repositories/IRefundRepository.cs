using Refunds.Core.Entities;

namespace Refunds.Core.Interfaces.Repositories
{
    public interface IRefundRepository : IRepository<Refund>
    {
        public void Update(Refund refund);
        public void Save();
        public void AuthorizeRefund(int id);
        public void SendRefundToReview(int id);
        public void SendRefundToPayment(int id);
        public void DenyRefund(int id);

    }
}
