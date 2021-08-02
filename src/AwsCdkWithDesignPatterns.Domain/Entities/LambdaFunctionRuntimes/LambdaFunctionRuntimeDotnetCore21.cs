using Amazon.CDK.AWS.Lambda;

namespace AwsCdkWithDesignPatterns.Domain.Entities.LambdaFunctionRuntimes
{
    public class LambdaFunctionRuntimeDotnetCore21 : ILambdaFunctionRuntime
    {
        public Runtime GetRuntime()
        {
            return Runtime.DOTNET_CORE_2_1;
        }
    }
}