using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        static ServiceTool()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddHttpContextAccessor();
            serviceCollection.AddScoped<HttpClient>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
