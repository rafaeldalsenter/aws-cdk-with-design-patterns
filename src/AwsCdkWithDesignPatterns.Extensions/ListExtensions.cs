using System.Collections.Generic;

namespace AwsCdkWithDesignPatterns.Extensions
{
    public static class ListExtensions
    {
        public static string ToStringConcat(this IList<string> value)
        {
            return value is null ? "" : string.Join(";", value);
        }
    }
}