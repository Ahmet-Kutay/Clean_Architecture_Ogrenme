using CleanArchitecture.Application.Services;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;

namespace CleanArchitecture.Infrastructure.Services
{
    public sealed class MailService : IMailService
    {
        private readonly string _smtpServer;
        private readonly int _port;
        private readonly string _senderEmail;
        private readonly string _password;

        public MailService(string smtpServer, int port, string senderEmail, string password)
        {
            _smtpServer = smtpServer;
            _port = port;
            _senderEmail = senderEmail;
            _password = password;
        }

        public async Task SendMailAsync(List<string> emails, string subject, string body, List<Attachment> attachments = null)
        {
            using var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_senderEmail);

            foreach (var email in emails)
            {
                mailMessage.To.Add(email);
            }

            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;

            if (attachments != null)
            {
                foreach (var attachment in attachments)
                {
                    mailMessage.Attachments.Add(attachment);
                }
            }

            using var smtpClient = new SmtpClient(_smtpServer)
            {
                Port = _port,
                Credentials = new NetworkCredential(_senderEmail, _password),
                EnableSsl = true
            };

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}