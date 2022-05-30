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
