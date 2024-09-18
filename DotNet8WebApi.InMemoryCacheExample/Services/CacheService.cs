using Microsoft.Extensions.Caching.Memory;

namespace DotNet8WebApi.InMemoryCacheExample.Services
{
    public class CacheService
    {
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void Set<T>(string key, T value)
        {

            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20),
                SlidingExpiration = TimeSpan.FromMinutes(15),
                Size = 1024
            };
            _cache.Set<T>(key, value, cacheEntryOptions);
        }

        public T? Get<T>(string key)
        {
            return _cache.TryGetValue(key, out T? cacheEntry) ? cacheEntry : default;
        }
    }
}
