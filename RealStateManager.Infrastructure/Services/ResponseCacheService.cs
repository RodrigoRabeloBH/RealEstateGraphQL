using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RealStateManager.Domain.Interfaces;
using StackExchange.Redis;

namespace RealStateManager.Infrastructure.Services
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDatabase _database;
        private readonly ILogger<ResponseCacheService> _logger;

        public ResponseCacheService(IConnectionMultiplexer redis, ILogger<ResponseCacheService> logger)
        {
            _database = redis.GetDatabase();
            _logger = logger;
        }

        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive)
        {
            if (response == null)
            {
                return;
            }
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var serialisedResponse = JsonSerializer.Serialize(response, options);

            await _database.StringSetAsync(cacheKey, serialisedResponse, timeToLive);
        }
        public async Task<string> GetCacheResponseAsync(string cachekey)
        {
            var cacheResponse = await _database.StringGetAsync(cachekey);

            if (string.IsNullOrEmpty(cacheResponse))
            {
                return null;
            }
            return cacheResponse;
        }
    }
}