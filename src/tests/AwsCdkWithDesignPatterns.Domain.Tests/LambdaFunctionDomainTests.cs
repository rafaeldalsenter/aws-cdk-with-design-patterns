using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;
using AwsCdkWithDesignPatterns.Domain.Builders;
using Xunit;

namespace AwsCdkWithDesignPatterns.Domain.Tests
{
    public class LambdaFunctionDomainTests
    {
        [Fact]
        public void LambdaFunctionDomain_WithoutHandler()
        {
            var result = new LambdaFunctionBuilder()
                .WithDescription("description")
                .WithName("functionName")
                .WithRuntime(Runtime.DOTNET_CORE_3_1)
                .WithTimeout(Duration.Seconds(10))
                .Build();

            Assert.False(result.IsValid());
        }

        [Fact]
        public void LambdaFunctionDomain_WithRuntimeDiffDotnetCore()
        {
        }

        [Fact]
        public void LambdaFunctionDomain_WithoutDescriptionAndName()
        {
        }

        [Fact]
        public void LambdaFunctionDomain_Ok()
        {
        }
    }
}