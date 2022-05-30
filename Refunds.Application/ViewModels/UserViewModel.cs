using Refunds.Core.Entities;

namespace Refunds.Application.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<RefundViewModel>? Refounds { get; set; }
        //Navigation
        public Department? Department { get; set; }

        //Parameterless constructor
        public UserViewModel() { }
    }


}
