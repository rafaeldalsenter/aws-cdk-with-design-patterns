using System;
using Amazon.CDK;
using AwsCdkWithDesignPatterns.Domain;
using AwsCdkWithDesignPatterns.Domain.Builders;
using AwsCdkWithDesignPatterns.Domain.Factories;
using AwsCdkWithDesignPatterns.Domain.LambdaFunctionRuntimes;

namespace AwsCdkExtensions.AwsLambdaFunctions
{
    public class HelloWorldFunction : LambdaFunctionFactory
    {
        public HelloWorldFunction(Construct construct) : base(construct)
        {
        }

        protected override LambdaFunctionDomain FactoryMethod()
        {
            return new LambdaFunctionBuilder()
                .WithDescription("description")
                .WithHandler("hello.handler")
                .WithName("functionName")
                .WithRuntime(new LambdaFunctionRuntimeDotnetCore31())
                .WithTimeout(TimeSpan.FromSeconds(10))
                .Build();
        }
    }
}