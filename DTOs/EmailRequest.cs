namespace GitHubRepoSearchApi.DTOs
{
    public class EmailRequest
    {
        public string Email { get; set; } = string.Empty;
        public string RepoName { get; set; } = string.Empty;
        public string OwnerLogin { get; set; } = string.Empty;
        public string RepoUrl { get; set; } = string.Empty;
    }
}
