using Microsoft.AspNetCore.Mvc;
using Reembolso.Models;

namespace Reembolso.Repository.IRepository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        void Save();
        void Update(Department department);

    }
}
