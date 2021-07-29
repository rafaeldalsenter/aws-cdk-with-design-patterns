using System;
using System.Collections.Generic;
using System.Linq;

namespace AwsCdkWithDesignPatterns.Extensions
{
    public static class AppDomainExtensions
    {
        public static IList<Type> GetClassesImplementingInterface<T>(this AppDomain appDomain)
        {
            return appDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(T).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToList();
        }
    }
}