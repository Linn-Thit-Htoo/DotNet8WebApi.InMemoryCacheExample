namespace DotNet8WebApi.InMemoryCacheExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogV1Controller : ControllerBase
{
    private readonly CacheService _cacheService;
    private readonly string _key;

    public BlogV1Controller(CacheService cacheService)
    {
        _cacheService = cacheService;
        _key = "Blogs";
    }

    [HttpGet]
    public IActionResult GetBlogs()
    {
        var cachedData = _cacheService.Get<List<BlogModel>>(_key);
        if (cachedData is not null)
        {
            return Ok(cachedData);
        }

        var lst = new List<BlogModel>()
        {
            new(1, "Blog Title 1", "Blog Author 1", "Blog Content 1"),
            new(1, "Blog Title 2", "Blog Author 2", "Blog Content 2"),
            new(1, "Blog Title 3", "Blog Author 3", "Blog Content 3"),
            new(1, "Blog Title 4", "Blog Author 4", "Blog Content 4"),
            new(1, "Blog Title 5", "Blog Author 5", "Blog Content 5"),
            new(1, "Blog Title 6", "Blog Author 6", "Blog Content 6"),
            new(1, "Blog Title 7", "Blog Author 7", "Blog Content 7"),
            new(1, "Blog Title 8", "Blog Author 8", "Blog Content 8"),
            new(1, "Blog Title 9", "Blog Author 9", "Blog Content 9"),
            new(1, "Blog Title 10", "Blog Author 10", "Blog Content 10"),
            new(1, "Blog Title 11", "Blog Author 11", "Blog Content 11"),
            new(1, "Blog Title 12", "Blog Author 12", "Blog Content 12")
        };
        _cacheService.Set<List<BlogModel>>(_key, lst);

        return Ok(lst);
    }
}