using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;
using AwsCdkWithDesignPatterns.Domain;
using AwsCdkWithDesignPatterns.Domain.Builders;
using AwsCdkWithDesignPatterns.Domain.Factories;

namespace AwsCdkExtensions.AwsLambdaFunctions
{
    public class MaisUmHelloWorldFunction : LambdaFunctionFactory
    {
        public MaisUmHelloWorldFunction(Construct construct) : base(construct)
        {
        }

        protected override LambdaFunctionDomain FactoryMethod() =>
            new LambdaFunctionBuilder()
                .WithConstruct(Construct)
                .WithDescription("description1")
                .WithHandler("hello.handler")
                .WithName("functionName1")
                .WithRuntime(Runtime.DOTNET_CORE_3_1)
                .WithTimeout(Duration.Seconds(10))
                .Build();
    }
}