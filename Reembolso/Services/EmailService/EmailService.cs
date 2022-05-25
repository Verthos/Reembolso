using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using Reembolso.Models;
using MailKit.Net.Smtp;

namespace Reembolso.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public void SendEmail(Mail request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config["Emailconfig:Username"]));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config["Emailconfig:Host"], 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config["Emailconfig:Username"], _config["Emailconfig:Password"]);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
