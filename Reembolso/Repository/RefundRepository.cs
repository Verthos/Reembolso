using MtgDataAPI.Data;
using Reembolso.Models;
using Reembolso.Repository.IRepository;

namespace Reembolso.Repository
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
    }
}
