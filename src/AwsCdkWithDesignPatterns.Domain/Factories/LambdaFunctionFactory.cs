using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;
using AwsCdkWithDesignPatterns.Domain.Entities;

namespace AwsCdkWithDesignPatterns.Domain.Factories
{
    public abstract class LambdaFunctionFactory : AbstractFactory<LambdaFunction, Function>
    {
        protected LambdaFunctionFactory(Construct construct) : base(construct)
        {
        }

        internal override Function CreateAwsCdkResource(LambdaFunction domain)
        {
            return new(Construct, domain.FunctionName,
                new FunctionProps
                {
                    Runtime = domain.Runtime.GetRuntime(),
                    Handler = domain.Handler,
                    Description = domain.Description,
                    FunctionName = domain.FunctionName,
                    Timeout = Duration.Seconds(domain.Timeout.Seconds),
                    Code = Code.FromAsset("lambda")
                });
        }
    }
}