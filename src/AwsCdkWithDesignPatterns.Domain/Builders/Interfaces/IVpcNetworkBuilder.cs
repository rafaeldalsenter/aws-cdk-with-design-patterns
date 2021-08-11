using AwsCdkWithDesignPatterns.Domain.Entities;

namespace AwsCdkWithDesignPatterns.Domain.Builders.Interfaces
{
    public interface IVpcNetworkBuilder
    {
        VpcNetwork Build();

        IVpcNetworkBuilder WithName(string name);

        IVpcNetworkBuilder WithCidr(string cidr);

        IVpcNetworkBuilder WithMaxAzs(int maxAzs);
    }
}