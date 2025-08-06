using GitHubRepoSearchApi.BL.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

public class GitHubService : IGitHubService
{
    private readonly HttpClient _httpClient;

    public GitHubService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> SearchRepositoriesAsync(string query)
    {
        var url = $"https://api.github.com/search/repositories?q={query}";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("User-Agent", "GitHubRepoSearchApp");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}
