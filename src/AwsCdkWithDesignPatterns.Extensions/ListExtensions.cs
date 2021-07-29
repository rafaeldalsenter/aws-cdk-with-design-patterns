using System.Collections.Generic;

namespace AwsCdkWithDesignPatterns.Extensions
{
    public static class ListExtensions
    {
        public static string ToStringConcat(this IList<string> value)
        {
            if (value is null) return "";

            return string.Join(";", value);
        }
    }
}