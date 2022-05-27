using Refunds.Core.Entities;

namespace Reembolso.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(Email email);
    }
}
