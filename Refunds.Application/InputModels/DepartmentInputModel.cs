namespace Refunds.Application.InputModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int ManagerId { get; set; }
        public List<UserInputModel>? Users { get; set; }
    }
}
