namespace Refunds.Core.Interfaces.Email
{
    public interface IEmailService<T>
    {
        void SendEmail(T email);
    }
}
