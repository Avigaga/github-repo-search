using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BookmarksController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public BookmarksController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    [HttpPost("bookmark")]
    public IActionResult AddBookmark([FromBody] Dictionary<string, object> repo)
    {
        var bookmarks = HttpContext.Session.GetObject<List<Dictionary<string, object>>>("bookmarks") ?? new List<Dictionary<string, object>>();
        // אפשר למנוע כפילויות אם רוצים, למשל לבדוק לפי id
        if (!bookmarks.Any(b => b["id"].ToString() == repo["id"].ToString()))
        {
            bookmarks.Add(repo);
            HttpContext.Session.SetObject("bookmarks", bookmarks);
            return Ok(new { success = true });
        }
        return Conflict("Already bookmarked");
    }

    [HttpGet("bookmarks")]
    public IActionResult GetBookmarks()
    {
        var bookmarks = HttpContext.Session.GetObject<List<Dictionary<string, object>>>("bookmarks") ?? new List<Dictionary<string, object>>();
        return Ok(bookmarks);
    }

    [HttpPost("remove-bookmark")]
    public IActionResult RemoveBookmark([FromBody] string id)
    {
        var bookmarks = HttpContext.Session.GetObject<List<Dictionary<string, object>>>("bookmarks") ?? new List<Dictionary<string, object>>();
        bookmarks = bookmarks.Where(b => b["id"].ToString() != id).ToList();
        HttpContext.Session.SetObject("bookmarks", bookmarks);
        return Ok();
    }
}
