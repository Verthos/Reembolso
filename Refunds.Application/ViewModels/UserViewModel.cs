namespace Refunds.Application.ViewModels
{
    public class UserViewModel
    {


        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<RefundViewModel>? Refounds { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsManager { get; set; } = false;
        public bool IsDirector { get; set; } = false;

        //Navigation
        public DepartmentViewModel? Department { get; set; }
        public int? DepartmentId { get; set; }


        //Parameterless constructor
        public UserViewModel() { }

        //New User constructor
        public UserViewModel(string name, string lastName, string email, int departmentId, string password)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Department.Id = departmentId;
            Refounds = new List<RefundViewModel>();
        }

        //claims constructor
        public UserViewModel(string name, string email, int departmentId, bool isAdmin, bool isManager)
        {
            Name = name;
            IsManager = isManager;
            IsAdmin = isAdmin;
            Email = email;
            Department.Id = departmentId;
            Refounds = new List<RefundViewModel>();
        }
    }


}
