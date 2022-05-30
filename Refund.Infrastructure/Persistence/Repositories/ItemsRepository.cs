using Refunds.Core.Entities;
using Refunds.Core.Interfaces.Repositories;

namespace Refunds.Infrastructure.Persistence.Repositories
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
