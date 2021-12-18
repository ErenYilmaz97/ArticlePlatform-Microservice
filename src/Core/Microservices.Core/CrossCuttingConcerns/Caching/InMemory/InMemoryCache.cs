using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.CrossCuttingConcerns.Caching.InMemory
{
    public class InMemoryCache : ICache
    {
        private readonly IMemoryCache _memoryCache;


        public InMemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
            

        public TReturnType GetFromCache<TReturnType>(string cacheKey)
        {
            if (this.IsKeyExist(cacheKey))
                return this._memoryCache.Get<TReturnType>(cacheKey);

            return default(TReturnType);
        }


        public bool IsKeyExist(string cacheKey)
        {
            return this._memoryCache.TryGetValue(cacheKey, out _);
        }


        public void SetToCache<TValueType>(string cacheKey, TValueType value)
        {
            this._memoryCache.Set<TValueType>(cacheKey, value);
        }


        public void SetToCacheWithDuration<TValueType>(string cacheKey, TValueType value, DateTime duration)
        {
            var expiryTimeSpan = duration.Subtract(DateTime.UtcNow);
            this._memoryCache.Set<TValueType>(cacheKey, value, expiryTimeSpan);
        }
    }
}
