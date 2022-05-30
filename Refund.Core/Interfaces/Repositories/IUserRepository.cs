using Refunds.Core.Entities;

namespace Refunds.Core.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {

        void Update(User user);

        void Save();
    }
}
