using System.Collections.Generic;
using System.Collections.ObjectModel;
using Flunt.Notifications;
using Xunit;

namespace AwsCdkWithDesignPatterns.Extensions.Tests
{
    public class ReadOnlyCollectionExtensionsTests
    {
        [Fact]
        public void ToStringConcat_NullableList()
        {
            var nullableReadOnlyCollection = null as IReadOnlyCollection<Notification>;

            var result = nullableReadOnlyCollection.ToStringConcat();

            Assert.Equal("", result);
        }

        [Fact]
        public void ToStringConcat_EmptyList()
        {
            var emptyReadOnlyCollection = new ReadOnlyCollection<Notification>(new List<Notification>());

            var result = emptyReadOnlyCollection.ToStringConcat();

            Assert.Equal("", result);
        }

        [Fact]
        public void ToStringConcat_OneItemList()
        {
            var oneItemReadOnlyCollection = new ReadOnlyCollection<Notification>(new List<Notification>
            {
                new("key1", "value1")
            });

            var result = oneItemReadOnlyCollection.ToStringConcat();

            Assert.Equal("key1 : value1", result);
        }

        [Fact]
        public void ToStringConcat_ManyItemsList()
        {
            var readOnlyCollection = new ReadOnlyCollection<Notification>(new List<Notification>
            {
                new("key1", "value1"),
                new("key2", "value2")
            });

            var result = readOnlyCollection.ToStringConcat();

            Assert.Equal("key1 : value1\nkey2 : value2", result);
        }
    }
}