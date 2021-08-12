using System.Text.RegularExpressions;

namespace AwsCdkWithDesignPatterns.Extensions
{
    public static class CidrSintaxExtensions
    {
        private const string _regexCidr =
            @"^(?<adr>([\d.]+)|([\da-f:]+(:[\d.]+)?(%\w+)?))[ \t]*/[ \t]*(?<maskLen>\d+)$";

        public static bool IsValidCidr(this string value)
        {
            return value is not null &&
                   new Regex(_regexCidr, RegexOptions.IgnoreCase | RegexOptions.Compiled).IsMatch(value);
        }
    }
}