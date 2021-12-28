using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microservices.Core.Utilities.Interceptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.IoC
{
    public class IdentityDependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new MethodInterceptorSelector()
                }).SingleInstance();
        }
    }
}
