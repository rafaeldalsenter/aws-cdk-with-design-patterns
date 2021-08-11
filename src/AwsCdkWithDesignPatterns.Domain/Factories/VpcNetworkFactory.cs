using Amazon.CDK;
using Amazon.CDK.AWS.EC2;
using AwsCdkWithDesignPatterns.Domain.Entities;
using AwsCdkWithDesignPatterns.Domain.Factories.Interfaces;

namespace AwsCdkWithDesignPatterns.Domain.Factories
{
    public abstract class VpcNetworkFactory : AbstractFactory<VpcNetwork, Vpc>
    {
        protected VpcNetworkFactory(Construct construct) : base(construct)
        {
        }

        internal override Vpc CreateAwsCdkResource(VpcNetwork domain)
        {
            return new(Construct, domain.Name,
                new VpcProps
                {
                    Cidr = domain.Cidr,
                    MaxAzs = domain.MaxAzs
                });
        }
    }
}