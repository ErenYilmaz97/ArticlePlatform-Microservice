using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisConfiguration
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public int DbIndex { get; set; }
    }
}
