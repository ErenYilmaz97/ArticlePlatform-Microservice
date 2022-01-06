using Microservice.Identity.Application.Caching;
using Microservices.Core.CrossCuttingConcerns.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Infrastructure.Caching
{
    public class IdentityCache : IIdentityCache
    {
        private readonly ICache _cache;

        public IdentityCache(ICache cache)
        {
            this._cache = cache;
        }




    }
}
