using Xunit;

namespace AwsCdkWithDesignPatterns.Extensions.Tests
{
    public class CidrSintaxExtensionsTests
    {
        [Theory]
        [InlineData("10.0.0.0/24")]
        [InlineData("192.168.0.0/16")]
        public void IsValidCidr_Ok(string value)
        {
            var result = value.IsValidCidr();
            Assert.True(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("any value")]
        [InlineData("192.168.1.1")]
        public void IsValidCidr_InvalidValue(string value)
        {
            var result = value.IsValidCidr();
            Assert.False(result);
        }
    }
}