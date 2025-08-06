using GitHubRepoSearchApi.BL.Interfaces;
using GitHubRepoSearchApi.BL.Session;
using Microsoft.AspNetCore.Http;

namespace GitHubRepoSearchApi.BL.Services
{
    public class BookmarkService : IBookmarkService
    {
        private const string SessionKey = "bookmarks";

        public bool AddBookmark(HttpContext httpContext, Dictionary<string, object> repo)
        {
            var session = httpContext.Session;
            var bookmarks = SessionManager.GetObject<List<Dictionary<string, object>>>(session, SessionKey)
                           ?? new List<Dictionary<string, object>>();

            if (!bookmarks.Any(b => b["id"].ToString() == repo["id"].ToString()))
            {
                bookmarks.Add(repo);
                SessionManager.SetObject(session, SessionKey, bookmarks);
                return true;
            }

            return false;
        }

        public List<Dictionary<string, object>> GetBookmarks(HttpContext httpContext)
        {
            var session = httpContext.Session;
            return SessionManager.GetObject<List<Dictionary<string, object>>>(session, SessionKey)
                   ?? new List<Dictionary<string, object>>();
        }

        public void RemoveBookmark(HttpContext httpContext, string id)
        {
            var session = httpContext.Session;
            var bookmarks = SessionManager.GetObject<List<Dictionary<string, object>>>(session, SessionKey)
                           ?? new List<Dictionary<string, object>>();

            bookmarks = bookmarks.Where(b => b["id"].ToString() != id).ToList();
            SessionManager.SetObject(session, SessionKey, bookmarks);
        }
    }
}
