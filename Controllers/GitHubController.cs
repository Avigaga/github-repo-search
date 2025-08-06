using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitHubRepoSearchApi.Controllers
{
    using GitHubRepoSearchApi.BL.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubService _gitHubService;

        public GitHubController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchRepositories([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Query cannot be empty.");

            try
            {
                var content = await _gitHubService.SearchRepositoriesAsync(query);
                return Content(content, "application/json");
            }
            catch (HttpRequestException)
            {
                return StatusCode(503, "GitHub API request failed.");
            }
        }
    }

}
