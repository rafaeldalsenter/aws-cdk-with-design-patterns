using AwsCdkWithDesignPatterns.Domain.Builders.Interfaces;
using AwsCdkWithDesignPatterns.Domain.Entities;

namespace AwsCdkWithDesignPatterns.Domain.Builders
{
    public class VpcNetworkBuilder : IVpcNetworkBuilder
    {
        private string _cidr;
        private int _maxAzs;
        private string _name;

        public VpcNetwork Build()
        {
            return new(_name, _cidr, _maxAzs);
        }

        public IVpcNetworkBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public IVpcNetworkBuilder WithCidr(string cidr)
        {
            _cidr = cidr;
            return this;
        }

        public IVpcNetworkBuilder WithMaxAzs(int maxAzs)
        {
            _maxAzs = maxAzs;
            return this;
        }
    }
}