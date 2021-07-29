using System;
using System.Linq;
using Amazon.CDK;
using AwsCdkWithDesignPatterns.Domain.Factories.Interfaces;
using AwsCdkWithDesignPatterns.Extensions;

namespace AwsCdkExtensions
{
    public class DevelopmentStack : Stack
    {
        public DevelopmentStack(Construct scope, string id, IStackProps props = null) : base(
            scope, id, props)
        {
            AppDomain.CurrentDomain.GetClassesImplementingInterface<IFactory>()
                .ToList().ForEach(x =>
                {
                    var factory = (IFactory) Activator.CreateInstance(x, this);
                    factory.Create();
                });
        }
    }
}