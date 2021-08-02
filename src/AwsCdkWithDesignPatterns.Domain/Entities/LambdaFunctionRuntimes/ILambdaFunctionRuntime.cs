using Amazon.CDK.AWS.Lambda;

namespace AwsCdkWithDesignPatterns.Domain.Entities.LambdaFunctionRuntimes
{
    public interface ILambdaFunctionRuntime
    {
        Runtime GetRuntime();
    }
}