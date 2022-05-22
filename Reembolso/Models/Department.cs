

using Microsoft.EntityFrameworkCore;

namespace Reembolso.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ManagerId { get; set; }
        public List<User> Users { get; set; }
    }
}
