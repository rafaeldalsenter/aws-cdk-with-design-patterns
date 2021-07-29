using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;

namespace AwsCdkWithDesignPatterns.Domain.Builders.Interfaces
{
    public interface ILambdaFunctionBuilder
    {
        LambdaFunctionDomain Build();

        ILambdaFunctionBuilder WithHandler(string handler);

        ILambdaFunctionBuilder WithRuntime(Runtime runtime);

        ILambdaFunctionBuilder WithDescription(string description);

        ILambdaFunctionBuilder WithName(string name);

        ILambdaFunctionBuilder WithTimeout(Duration timeout);

        ILambdaFunctionBuilder WithConstruct(Construct construct);
    }
}