using System;
using Amazon.CDK;
using AwsCdkWithDesignPatterns.Domain.Builders;
using AwsCdkWithDesignPatterns.Domain.Entities;
using AwsCdkWithDesignPatterns.Domain.Entities.LambdaFunctionRuntimes;
using AwsCdkWithDesignPatterns.Domain.Factories;

namespace AwsCdkExtensions.AwsLambdaFunctions
{
    public class HelloWorldFunction : LambdaFunctionFactory
    {
        public HelloWorldFunction(Construct construct) : base(construct)
        {
        }

        protected override LambdaFunction FactoryMethod()
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