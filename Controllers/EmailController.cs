using GitHubRepoSearchApi.BL.Interfaces;
using GitHubRepoSearchApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("send-email")]
    public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
    {
        var result = await _emailService.SendEmailAsync(request);
        if (result)
            return Ok(new { success = true });
        else
            return StatusCode(500, "Error sending email.");
    }
}
