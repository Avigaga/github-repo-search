using GitHubRepoSearchApi.DTOs;

namespace GitHubRepoSearchApi.BL.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(EmailRequest request);
    }

}
