using Microsoft.AspNetCore.Http;

namespace GitHubRepoSearchApi.BL.Interfaces
{
    public interface IBookmarkService
    {
        bool AddBookmark(HttpContext httpContext, Dictionary<string, object> repo);
        List<Dictionary<string, object>> GetBookmarks(HttpContext httpContext);
        void RemoveBookmark(HttpContext httpContext, string id);
    }
}
