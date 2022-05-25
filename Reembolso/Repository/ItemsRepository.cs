using Reembolso.Data;
using Reembolso.Models;
using Reembolso.Repository.IRepository;

namespace Reembolso.Repository
{
    public class ItemsRepository : Repository<Item>, IItemsRepository
    {
        private readonly ReembolsoContext _db;
        public ItemsRepository(ReembolsoContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Item item)
        {
            _db.Update(item);
        }
    }
}
