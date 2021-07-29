using System;
using System.Collections.Generic;
using System.Linq;
using AwsCdkWithDesignPatterns.Extensions.Tests.Objects;
using Xunit;

namespace AwsCdkWithDesignPatterns.Extensions.Tests
{
    public class AppDomainExtensionsTests
    {
        [Fact]
        public void GetClassesImplementingInterface_OnlyAbstractClasses()
        {
            var result = AppDomain.CurrentDomain.GetClassesImplementingInterface<IAmphibian>()
                .ToList();

            Assert.Empty(result);
        }

        [Fact]
        public void GetClassesImplementingInterface_OnlyInterfaces()
        {
            var result = AppDomain.CurrentDomain.GetClassesImplementingInterface<IInsect>()
                .ToList();

            Assert.Empty(result);
        }

        [Fact]
        public void GetClassesImplementingInterface_OnlyClassesWithInheritence()
        {
            var expected = new List<Type>
            {
                typeof(Hawk), typeof(Owl)
            };

            var result = AppDomain.CurrentDomain.GetClassesImplementingInterface<IBird>()
                .ToList();

            Assert.Equal(expected, result);
        }
    }
}