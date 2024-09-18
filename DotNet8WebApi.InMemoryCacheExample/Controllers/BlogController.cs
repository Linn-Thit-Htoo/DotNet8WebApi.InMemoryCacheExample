using DotNet8WebApi.InMemoryCacheExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DotNet8WebApi.InMemoryCacheExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public BlogController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            if (_memoryCache.TryGetValue("Blogs", out List<BlogModel> blogs))
            {
                return Ok(blogs);
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

            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20),
                SlidingExpiration = TimeSpan.FromMinutes(15),
                Size = 1024
            };
            _memoryCache.Set<List<BlogModel>>("Blogs", lst, cacheEntryOptions);

            return Ok(lst);
        }
    }
}