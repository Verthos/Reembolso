using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Identity.Core;

namespace Reembolso.Models
{
    public class User
    {


        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Refund>? Refounds { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsManager { get; set; } = false;
        public bool IsDirector { get; set; } = false;

        //Navigation
        public Department? Department { get; set; }
        public int ? DepartmentId { get; set; }        


        //Parameterless constructor
        public User() { }

        //New User constructor
        public User(string name, string lastName, string email, int departmentId, string password)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.Department.Id = departmentId;
            this.Refounds = new List<Refund>();
        }

        //claims constructor
        public User(string name, string email, int departmentId, bool isAdmin, bool isManager)
        {
            this.Name = name;
            this.IsManager = isManager;
            this.IsAdmin = isAdmin;
            this.Email = email;
            this.Department.Id = departmentId;
            this.Refounds = new List<Refund>();
        }
    }


}
