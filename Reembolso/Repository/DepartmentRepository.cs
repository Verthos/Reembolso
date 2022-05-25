using Reembolso.Data;
using Reembolso.Models;
using Reembolso.Repository.IRepository;

namespace Reembolso.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly ReembolsoContext _db;
        public DepartmentRepository(ReembolsoContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Department department)
        {
            _db.Update(department);
        }
    }
}
