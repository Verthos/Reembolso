using Refunds.Core.Entities;

namespace Refunds.Core.Interfaces.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        void Save();
        void Update(Department department);

    }
}
