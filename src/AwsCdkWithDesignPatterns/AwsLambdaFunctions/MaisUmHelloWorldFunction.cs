using System;
using Amazon.CDK;
using AwsCdkWithDesignPatterns.Domain;
using AwsCdkWithDesignPatterns.Domain.Builders;
using AwsCdkWithDesignPatterns.Domain.Factories;
using AwsCdkWithDesignPatterns.Domain.LambdaFunctionRuntimes;

namespace AwsCdkExtensions.AwsLambdaFunctions
{
    public class MaisUmHelloWorldFunction : LambdaFunctionFactory
    {
        public MaisUmHelloWorldFunction(Construct construct) : base(construct)
        {
        }

        protected override LambdaFunctionDomain FactoryMethod()
        {
            return new LambdaFunctionBuilder()
                .WithDescription("description1")
                .WithHandler("hello.handler")
                .WithName("functionName1")
                .WithRuntime(new LambdaFunctionRuntimeDotnetCore31())
                .WithTimeout(TimeSpan.FromSeconds(10))
                .Build();
        }
    }
}