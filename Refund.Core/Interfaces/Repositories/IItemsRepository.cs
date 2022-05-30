using Refunds.Core.Entities;

namespace Refunds.Core.Interfaces.Repositories
{
    public interface IItemsRepository : IRepository<Item>
    {
        void Update(Item item);

        void Save();
    }
}
