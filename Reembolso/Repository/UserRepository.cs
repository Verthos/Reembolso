using MtgDataAPI.Data;
using Reembolso.Models;
using Reembolso.Repository.IRepository;

namespace Reembolso.Repository
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
            _db.Users.Update(user);
        }
    }
}
