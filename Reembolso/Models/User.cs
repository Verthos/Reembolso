namespace Reembolso.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Refund> refounds { get; set; }
        public bool isAdmin { get; set; }
        public bool isManager { get; set; }
        public bool isDirector { get; set; }
        public List<User> subordinates { get; set; }



        //Navigation
        public string ManagerName { get; set; }
        public int ManagerId { get; set; }
        public string Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
