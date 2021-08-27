using System;
using System.Threading.Tasks;

namespace RealStateManager.Domain.Interfaces
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive);
        Task<string> GetCacheResponseAsync(string cachekey);
    }
}