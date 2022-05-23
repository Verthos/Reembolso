using Reembolso.Models;

namespace Reembolso.Auth
{
    public interface IAuth
    {
        User AuthenticateUser(string user, string password);

        string GenerateToken(User user);
    }
}
