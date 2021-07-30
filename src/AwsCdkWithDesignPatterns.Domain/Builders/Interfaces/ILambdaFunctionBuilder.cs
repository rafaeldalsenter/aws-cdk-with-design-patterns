using System;
using AwsCdkWithDesignPatterns.Domain.LambdaFunctionRuntimes;

namespace AwsCdkWithDesignPatterns.Domain.Builders.Interfaces
{
    public interface ILambdaFunctionBuilder
    {
        LambdaFunctionDomain Build();

        ILambdaFunctionBuilder WithHandler(string handler);

        ILambdaFunctionBuilder WithRuntime(ILambdaFunctionRuntime runtime);

        ILambdaFunctionBuilder WithDescription(string description);

        ILambdaFunctionBuilder WithName(string name);

        ILambdaFunctionBuilder WithTimeout(TimeSpan timeout);
    }
}