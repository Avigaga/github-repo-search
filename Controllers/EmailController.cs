using GitHubRepoSearchApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;

[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly EmailSettings _emailSettings;

    public EmailController(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    [HttpPost("send-email")]
    public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
    {
        var smtpServer = _emailSettings.SmtpServer;
        var smtpPort = _emailSettings.SmtpPort;
        var senderEmail = _emailSettings.SenderEmail;
        var senderPassword = _emailSettings.SenderPassword;

        try
        {
            var mail = new MailMessage();
            mail.To.Add(request.Email);
            mail.From = new MailAddress(senderEmail);
            mail.Subject = $"GitHub Repository info: {request.RepoName}";
            mail.Body = $"Repository Name: {request.RepoName}\n" +
                        $"Owner: {request.OwnerLogin}\n" +
                        $"URL: {request.RepoUrl}\n";

            using var smtpClient = new SmtpClient(smtpServer, smtpPort)
            {
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true,
            };

            await smtpClient.SendMailAsync(mail);

            return Ok(new { success = true });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error sending email: {ex.Message}");
        }
    }
}
