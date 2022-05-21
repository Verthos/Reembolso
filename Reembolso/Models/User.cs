using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Identity.Core;

namespace Reembolso.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public List<Refund>? Refounds { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsManager { get; set; } = false;
        public bool IsDirector { get; set; } = false;

        //Navigation
        public string? ManagerName { get; set; }
        public int ManagerId { get; set; } = 1;
        public string? Department { get; set; }
        public int DepartmentId { get; set; } = 1;





        //Parameterless constructor
        public User() { }

        //New User constructor
        public User(string name, string lastName, string email, int managerId, int departmentId, string password)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.ManagerId = managerId;
            this.DepartmentId = departmentId;
            this.Refounds = new List<Refund>();
        }


        //claims constructor
        public User(string name, string email, int departmentId, bool isAdmin, bool isManager)
        {
            this.Name = name;
            this.IsManager = isManager;
            this.IsAdmin = isAdmin;
            this.Email = email;
            this.DepartmentId = departmentId;
            this.Refounds = new List<Refund>();
        }
    }


}
