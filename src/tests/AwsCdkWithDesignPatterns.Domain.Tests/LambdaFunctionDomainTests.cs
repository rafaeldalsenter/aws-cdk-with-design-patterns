using System;
using AwsCdkWithDesignPatterns.Domain.Builders;
using AwsCdkWithDesignPatterns.Domain.Entities.LambdaFunctionRuntimes;
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
                .WithRuntime(new LambdaFunctionRuntimeDotnetCore31())
                .WithTimeout(TimeSpan.FromSeconds(10))
                .Build();

            Assert.False(result.IsValid);
        }

        [Fact]
        public void LambdaFunctionDomain_WithRuntimeDiffDotnetCore()
        {
            var result = new LambdaFunctionBuilder()
                .WithHandler("function.handler")
                .WithDescription("description")
                .WithName("functionName")
                .WithRuntime(new LambdaFunctionRuntimeDotnetCore2())
                .WithTimeout(TimeSpan.FromSeconds(10))
                .Build();

            Assert.False(result.IsValid);
        }

        [Fact]
        public void LambdaFunctionDomain_WithoutDescriptionAndName()
        {
            var result = new LambdaFunctionBuilder()
                .WithHandler("function.handler")
                .WithRuntime(new LambdaFunctionRuntimeDotnetCore31())
                .WithTimeout(TimeSpan.FromSeconds(10))
                .Build();

            Assert.False(result.IsValid);
        }

        [Fact]
        public void LambdaFunctionDomain_Ok()
        {
            var result = new LambdaFunctionBuilder()
                .WithHandler("function.handler")
                .WithDescription("description")
                .WithName("functionName")
                .WithRuntime(new LambdaFunctionRuntimeDotnetCore31())
                .WithTimeout(TimeSpan.FromSeconds(10))
                .Build();

            Assert.True(result.IsValid);
        }

        [Fact]
        public void LambdaFunctionDomain_AssignedTheValues()
        {
            var expectedHandler = "teste.handler";
            var expectedDescription = "description test";
            var expectedName = "test name";
            var expectedRuntime = new LambdaFunctionRuntimeDotnetCore31();
            var expectedTimeout = TimeSpan.FromSeconds(10);

            var result = new LambdaFunctionBuilder()
                .WithHandler(expectedHandler)
                .WithDescription(expectedDescription)
                .WithName(expectedName)
                .WithRuntime(expectedRuntime)
                .WithTimeout(expectedTimeout)
                .Build();

            Assert.Equal(expectedHandler, result.Handler);
            Assert.Equal(expectedDescription, result.Description);
            Assert.Equal(expectedName, result.FunctionName);
            Assert.IsType(expectedRuntime.GetType(), result.Runtime);
            Assert.Equal(expectedTimeout.Seconds, result.Timeout.Seconds);
        }
    }
}