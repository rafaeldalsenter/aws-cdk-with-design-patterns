using System;
using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;
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

        protected abstract LambdaFunctionDomain FactoryMethod();

        public void Create()
        {
            var functionLambdaDomain = FactoryMethod();

            if (!functionLambdaDomain.IsValid())
                throw new Exception(functionLambdaDomain.ErrorMessages.ToStringConcat());

            var function = new Function(functionLambdaDomain.Construct, functionLambdaDomain.FunctionName,
                new FunctionProps
                {
                    Runtime = functionLambdaDomain.Runtime,
                    Handler = functionLambdaDomain.Handler,
                    Description = functionLambdaDomain.Description,
                    FunctionName = functionLambdaDomain.FunctionName,
                    Timeout = functionLambdaDomain.Timeout,
                    Code = Code.FromAsset("lambda")
                });
        }
    }
}