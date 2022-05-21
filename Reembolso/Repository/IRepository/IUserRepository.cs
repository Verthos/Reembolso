using Reembolso.Models;

namespace Reembolso.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        

        void Update(User user);

        void Save();
    }
}
