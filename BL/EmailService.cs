using GitHubRepoSearchApi.BL.Interfaces;
using GitHubRepoSearchApi.DTOs;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace GitHubRepoSearchApi.BL
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmailAsync(EmailRequest request)
        {
            try
            {
                var mail = new MailMessage
                {
                    From = new MailAddress(_emailSettings.SenderEmail),
                    Subject = $"GitHub Repository info: {request.RepoName}",
                    Body = $"Repository Name: {request.RepoName}\n" +
                           $"Owner: {request.OwnerLogin}\n" +
                           $"URL: {request.RepoUrl}\n"
                };

                mail.To.Add(request.Email);

                using var smtpClient = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort)
                {
                    Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.SenderPassword),
                    EnableSsl = true,
                };

                await smtpClient.SendMailAsync(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
