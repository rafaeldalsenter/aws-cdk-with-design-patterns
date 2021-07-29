using System.Collections.Generic;
using Xunit;

namespace AwsCdkWithDesignPatterns.Extensions.Tests
{
    public class ListExtensionsTests
    {
        [Fact]
        public void ToStringConcat_NullableList()
        {
            var nullableList = null as IList<string>;

            var result = nullableList.ToStringConcat();

            Assert.Equal("", result);
        }

        [Fact]
        public void ToStringConcat_EmptyList()
        {
            var emptyList = new List<string>();

            var result = emptyList.ToStringConcat();

            Assert.Equal("", result);
        }

        [Fact]
        public void ToStringConcat_OneItemList()
        {
            var oneItemList = new List<string>
            {
                "Item1"
            };

            var result = oneItemList.ToStringConcat();

            Assert.Equal("Item1", result);
        }

        [Fact]
        public void ToStringConcat_ManyItemsList()
        {
            var oneItemList = new List<string>
            {
                "Item1", "Item2"
            };

            var result = oneItemList.ToStringConcat();

            Assert.Equal("Item1;Item2", result);
        }
    }
}