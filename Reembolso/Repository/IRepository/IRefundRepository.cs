using Reembolso.Models;

namespace Reembolso.Repository.IRepository
{
    public interface IRefundRepository : IRepository<Refund>
    {
        public void Update(Refund refund);
        public void Save();
    }
}
