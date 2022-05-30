namespace Refunds.Core.Interfaces.Auth
{
    public interface IAuth<T>
    {
        T AuthenticateUser(string user, string password);

        string GenerateToken(T user);
    }
}
