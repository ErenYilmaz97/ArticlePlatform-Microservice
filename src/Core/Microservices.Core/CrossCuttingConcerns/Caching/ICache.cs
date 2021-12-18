using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.CrossCuttingConcerns.Caching
{
    public interface ICache
    {
        public TReturnType GetFromCache<TReturnType>(string cacheKey);
        public void SetToCache<TValueType>(string cacheKey, TValueType value);
        public void SetToCacheWithDuration<TValueType>(string cacheKey, TValueType value, DateTime duration);
        public bool IsKeyExist(string cacheKey);
    }
}
