using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCache : ICache
    {
        private readonly RedisConfiguration _redisConfiguration;
        private IConnectionMultiplexer _connectionMultiplexer;
        private IDatabase _database;

        public RedisCache(IOptions<RedisConfiguration> redisConfig)
        {
            this._redisConfiguration = redisConfig.Value;
            this.StartConnection();
        }



        private void StartConnection()
        {
            var redisOptions = new ConfigurationOptions()
            {             
                EndPoints = { _redisConfiguration.Host, _redisConfiguration.Port },
                DefaultDatabase = _redisConfiguration.DbIndex  //Her Microservis için farklı
            };

            try
            {
                this._connectionMultiplexer = ConnectionMultiplexer.Connect(redisOptions);
                this._database = this._connectionMultiplexer.GetDatabase();
            }
            catch (Exception)
            {
                throw new ApplicationException("IdentityService - Redise Bağlantı Kurulamadı.");
            }
        }


        private void CheckConnection()
        {
            if (!this._connectionMultiplexer.IsConnected)
            {
                this.StartConnection();
            }           
        }



        public TReturnType GetFromCache<TReturnType>(string cacheKey)
        {
            if (this.IsKeyExist(cacheKey))
                return JsonConvert.DeserializeObject<TReturnType>(this._database.StringGet(cacheKey));

            return default(TReturnType);
        }


        public bool IsKeyExist(string cacheKey)
        {
            return this._database.KeyExists(cacheKey);
        }


        public void SetToCache<TValueType>(string cacheKey, TValueType value)
        {
            this._database.StringSet(cacheKey, JsonConvert.SerializeObject(value));
        }


        public void SetToCacheWithDuration<TValueType>(string cacheKey, TValueType value, DateTime duration)
        {
            var expiryTimeSpan = duration.Subtract(DateTime.UtcNow);
            this._database.StringSet(cacheKey, JsonConvert.SerializeObject(value) , expiryTimeSpan);
        }
    }
}
