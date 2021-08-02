using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;

namespace AwsCdkWithDesignPatterns.Extensions
{
    public static class ReadOnlyCollectionExtensions
    {
        public static string ToStringConcat(this IReadOnlyCollection<Notification> value)
        {
            return value is null ? "" : string.Join("\n", value.Select(x => $"{x.Key} : {x.Message}"));
        }
    }
}