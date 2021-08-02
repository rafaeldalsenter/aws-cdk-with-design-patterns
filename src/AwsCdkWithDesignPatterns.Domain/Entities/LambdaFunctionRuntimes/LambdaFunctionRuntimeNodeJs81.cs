using Amazon.CDK.AWS.Lambda;

namespace AwsCdkWithDesignPatterns.Domain.Entities.LambdaFunctionRuntimes
{
    public class LambdaFunctionRuntimeNodeJs81 : ILambdaFunctionRuntime
    {
        public Runtime GetRuntime()
        {
            return Runtime.NODEJS_8_10;
        }
    }
}