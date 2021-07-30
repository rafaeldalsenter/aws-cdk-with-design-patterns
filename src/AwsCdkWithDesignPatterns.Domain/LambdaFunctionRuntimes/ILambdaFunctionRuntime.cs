using Amazon.CDK.AWS.Lambda;

namespace AwsCdkWithDesignPatterns.Domain.LambdaFunctionRuntimes
{
    public interface ILambdaFunctionRuntime
    {
        Runtime GetRuntime();
    }
}