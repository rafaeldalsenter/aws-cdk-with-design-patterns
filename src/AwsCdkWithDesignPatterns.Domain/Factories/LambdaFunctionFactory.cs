using System;
using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;
using AwsCdkWithDesignPatterns.Domain.Entities;
using AwsCdkWithDesignPatterns.Domain.Factories.Interfaces;
using AwsCdkWithDesignPatterns.Extensions;

namespace AwsCdkWithDesignPatterns.Domain.Factories
{
    public abstract class LambdaFunctionFactory : IFactory
    {
        protected readonly Construct Construct;

        protected LambdaFunctionFactory(Construct construct)
        {
            Construct = construct;
        }

        public void Create()
        {
            var functionLambdaDomain = FactoryMethod();

            if (!functionLambdaDomain.IsValid)
                throw new Exception(functionLambdaDomain.Notifications.ToStringConcat());

            var function = new Function(Construct, functionLambdaDomain.FunctionName,
                new FunctionProps
                {
                    Runtime = functionLambdaDomain.Runtime.GetRuntime(),
                    Handler = functionLambdaDomain.Handler,
                    Description = functionLambdaDomain.Description,
                    FunctionName = functionLambdaDomain.FunctionName,
                    Timeout = Duration.Seconds(functionLambdaDomain.Timeout.Seconds),
                    Code = Code.FromAsset("lambda")
                });
        }

        protected abstract LambdaFunctionDomain FactoryMethod();
    }
}