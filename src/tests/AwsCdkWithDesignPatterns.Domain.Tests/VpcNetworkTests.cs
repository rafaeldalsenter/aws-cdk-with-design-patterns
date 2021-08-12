using AwsCdkWithDesignPatterns.Domain.Builders;
using Xunit;

namespace AwsCdkWithDesignPatterns.Domain.Tests
{
    public class VpcNetworkTests
    {
        [Fact]
        public void VpcNetwork_WithoutName()
        {
            var result = new VpcNetworkBuilder()
                .WithCidr("10.0.0.0/24")
                .WithMaxAzs(1)
                .Build();

            Assert.False(result.IsValid);
        }

        [Fact]
        public void VpcNetwork_WithInvalidMaxSize()
        {
            var result = new VpcNetworkBuilder()
                .WithCidr("10.0.0.0/24")
                .WithName("name")
                .WithMaxAzs(0)
                .Build();

            Assert.False(result.IsValid);
        }

        [Fact]
        public void VpcNetwork_WithInvalidCidr()
        {
            var result = new VpcNetworkBuilder()
                .WithCidr("invalid")
                .WithName("name")
                .WithMaxAzs(1)
                .Build();

            Assert.False(result.IsValid);
        }

        [Fact]
        public void VpcNetwork_Ok()
        {
            var result = new VpcNetworkBuilder()
                .WithCidr("10.0.0.0/24")
                .WithName("name")
                .WithMaxAzs(1)
                .Build();

            Assert.True(result.IsValid);
        }

        [Fact]
        public void VpcNetwork_AssignedTheValues()
        {
            var expectedCidr = "10.0.0.0/24";
            var expectedName = "testName";
            var expectedMaxAzs = 1;

            var result = new VpcNetworkBuilder()
                .WithCidr(expectedCidr)
                .WithName(expectedName)
                .WithMaxAzs(expectedMaxAzs)
                .Build();

            Assert.Equal(expectedCidr, result.Cidr);
            Assert.Equal(expectedName, result.Name);
            Assert.Equal(expectedMaxAzs, result.MaxAzs);
        }
    }
}