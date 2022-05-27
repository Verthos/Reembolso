using Refunds.Core.Entities;
using Refunds.Core.Interfaces.Repositories;
using System.Security.Claims;

namespace Refunds.Infrastructure.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ReembolsoContext _db;
        public UserRepository(ReembolsoContext db) : base(db)
        {
            _db = db;
        }

        public bool IsOwnerOrAdmin(ClaimsIdentity identity, int id)
        {
            _ = int.TryParse(identity.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value, out int ownerId);

            return identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value == "admin" || id == ownerId;
        }
        public bool IsDepartmentManagerOrAdmin(ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value == "admin" || identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value == "manager";
        }
        public bool IsDirectorOrAdmin(ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value == "admin" || identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value == "director";
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(User user)
        {
            //_db.Users.Update(user);
        }


    }
}
