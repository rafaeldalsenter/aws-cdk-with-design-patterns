using Amazon.CDK;
using AwsCdkWithDesignPatterns.Domain.Builders;
using AwsCdkWithDesignPatterns.Domain.Entities;
using AwsCdkWithDesignPatterns.Domain.Factories;

namespace AwsCdkExtensions.VpcNetworks
{
    public class VpcNetworkDevEnvironment : VpcNetworkFactory
    {
        public VpcNetworkDevEnvironment(Construct construct) : base(construct)
        {
        }

        protected override VpcNetwork FactoryMethod()
        {
            return new VpcNetworkBuilder()
                .WithCidr("")
                .WithName("")
                .WithMaxAzs(0)
                .Build();
        }
    }
}