using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;
using AwsCdkWithDesignPatterns.Domain;
using AwsCdkWithDesignPatterns.Domain.Builders;
using AwsCdkWithDesignPatterns.Domain.Factories;

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
                .WithConstruct(Construct)
                .WithDescription("description")
                .WithHandler("hello.handler")
                .WithName("functionName")
                .WithRuntime(Runtime.DOTNET_CORE_3_1)
                .WithTimeout(Duration.Seconds(10))
                .Build();
        }
    }
}