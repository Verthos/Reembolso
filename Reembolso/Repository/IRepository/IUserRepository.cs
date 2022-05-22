using Reembolso.Models;
using System.Security.Claims;

namespace Reembolso.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        bool IsOwnerOrAdmin(ClaimsIdentity identity, int id);
        public bool IsDepartmentManagerOrAdmin(ClaimsIdentity identity);
        public bool IsDirectorOrAdmin(ClaimsIdentity identity);

        void Update(User user);

        void Save();
    }
}
