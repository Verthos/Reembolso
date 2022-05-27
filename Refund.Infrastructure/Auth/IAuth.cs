using Refunds.Core.Entities;

namespace Refunds.Infrastructure.Auth
{
    public interface IAuth
    {
        User AuthenticateUser(string user, string password);

        string GenerateToken(User user);
    }
}
