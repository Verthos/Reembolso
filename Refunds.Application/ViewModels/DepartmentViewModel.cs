namespace Refunds.Application.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int ManagerId { get; set; }
        public List<UserViewModel>? Users { get; set; }
    }
}
