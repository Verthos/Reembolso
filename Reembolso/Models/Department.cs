

using Microsoft.EntityFrameworkCore;

namespace Reembolso.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int ManagerId { get; set; }
        public List<User>? Users { get; set; }
    }
}
