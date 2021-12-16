using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.Utilities.Interceptor
{
    public class MethodInterceptorSelector : IInterceptorSelector
    {
        //Methodların üzerindeki aspect attributeları yakalayarak sırası ile execute eder.
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            //TÜM METHODLARA, MANUEL OLARAK BU ASPECTİ EKLE
            //classAttributes.Insert(0, new ExceptionAspect(typeof(DatabaseLogger)));

            return classAttributes.ToArray();
        }
    }
}
