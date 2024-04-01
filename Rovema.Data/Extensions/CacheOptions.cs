using Microsoft.Extensions.Caching.Distributed;

namespace Rovema.Data.Extensions;

public static class CacheOptions
{
    public static DistributedCacheEntryOptions DefaultExpiration =>
        new() { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60) };
}