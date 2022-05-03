using Microsoft.Extensions.Caching.Distributed;


namespace OrderManagementSystem.Domain
{
  public interface IDistributedCacheRepository
  {
    
    Task<string> GetAsync(string cacheKey);

    Task SetAsync(string cacheKey, string cacheValue, DistributedCacheEntryOptions cacheEntryOptions);

    Task PurgeAsync(string cacheKey);
  }
}
