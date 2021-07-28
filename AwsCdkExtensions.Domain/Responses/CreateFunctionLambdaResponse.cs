using System.Collections.Generic;
using System.Linq;
using Amazon.CDK.AWS.Lambda;

namespace AwsCdkExtensions.Domain.Responses
{
    public class CreateFunctionLambdaResponse
    {
        public IList<string> ErrorMessages { get; set; }
        public bool IsValid() => !ErrorMessages?.Any() ?? true;
        public Function Function { get; set; }
    }
}