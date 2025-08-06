namespace GitHubRepoSearchApi.BL.Interfaces
{
    // ב־BL/Interfaces/IGitHubService.cs
    public interface IGitHubService
    {
        Task<string> SearchRepositoriesAsync(string query);
    }

}
