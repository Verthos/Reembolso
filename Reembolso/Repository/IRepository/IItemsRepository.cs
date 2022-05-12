using Reembolso.Models;

namespace Reembolso.Repository.IRepository
{
    public interface IItemsRepository : IRepository<Item>
    {
        void Update(Item item);

        void Save();
    }
}
