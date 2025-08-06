using GitHubRepoSearchApi.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class BookmarksController : ControllerBase
{
    private readonly IBookmarkService _bookmarkService;

    public BookmarksController(IBookmarkService bookmarkService)
    {
        _bookmarkService = bookmarkService;
    }

    [HttpPost("bookmark")]
    public IActionResult AddBookmark([FromBody] Dictionary<string, object> repo)
    {
        var success = _bookmarkService.AddBookmark(HttpContext, repo);
        if (success)
            return Ok(new { success = true });
        return Conflict("Already bookmarked");
    }

    [HttpGet("bookmarks")]
    public IActionResult GetBookmarks()
    {
        var bookmarks = _bookmarkService.GetBookmarks(HttpContext);
        return Ok(bookmarks);
    }

    [HttpPost("remove-bookmark")]
    public IActionResult RemoveBookmark([FromBody] string id)
    {
        _bookmarkService.RemoveBookmark(HttpContext, id);
        return Ok();
    }
}

