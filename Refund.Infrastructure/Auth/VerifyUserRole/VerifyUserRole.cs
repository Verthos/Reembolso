using System.Security.Claims;

namespace Refunds.Infrastructure.Auth.VerifyUserRole
{
    public class VerifyUserRole : IVerifyUserRole
    {
        public bool IsOwnerOrAdmin(ClaimsIdentity identity, int id)
        {
            _ = int.TryParse(identity.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value, out int ownerId);

            return identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value == "admin" || id == ownerId;
        }
        public bool IsDepartmentManagerOrAdmin(ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value == "admin" || identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value == "manager";
        }
        public bool IsDirectorOrAdmin(ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value == "admin" || identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value == "director";
        }
    }
}
