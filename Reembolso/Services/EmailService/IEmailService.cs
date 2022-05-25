using Reembolso.Models;

namespace Reembolso.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(Mail mail);
    }
}
