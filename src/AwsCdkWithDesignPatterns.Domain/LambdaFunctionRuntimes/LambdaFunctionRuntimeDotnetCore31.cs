using Amazon.CDK.AWS.Lambda;

namespace AwsCdkWithDesignPatterns.Domain.LambdaFunctionRuntimes
{
    public class LambdaFunctionRuntimeDotnetCore31 : ILambdaFunctionRuntime
    {
        public Runtime GetRuntime()
        {
            return Runtime.DOTNET_CORE_3_1;
        }
    }
}