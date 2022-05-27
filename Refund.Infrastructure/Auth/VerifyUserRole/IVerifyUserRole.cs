using System.Security.Claims;
namespace Refunds.Infrastructure.Auth.VerifyUserRole
{
    public interface IVerifyUserRole
    {
        public bool IsOwnerOrAdmin(ClaimsIdentity identity, int id);

        public bool IsDepartmentManagerOrAdmin(ClaimsIdentity identity);

        public bool IsDirectorOrAdmin(ClaimsIdentity identity);
    }
}
