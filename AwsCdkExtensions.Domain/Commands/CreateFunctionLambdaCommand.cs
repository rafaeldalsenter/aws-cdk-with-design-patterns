using Amazon.CDK;
using Amazon.CDK.AWS.EC2;
using Amazon.CDK.AWS.Lambda;
using AwsCdkExtensions.Domain.Responses;
using MediatR;

namespace AwsCdkExtensions.Domain.Commands
{
    public class CreateFunctionLambdaCommand : IRequest<CreateFunctionLambdaResponse>
    {
        public string Handler { get; private set; }
        public Runtime Runtime { get; private set; }
        public string Description { get; private set; }
        public string FunctionName { get; private set; }
        public Construct Construct { get; private set; }
        public Duration Timeout { get; private set; }
        
        public CreateFunctionLambdaCommand(string handler, Runtime runtime, string description, string functionName, Duration timeout, Construct construct)
        {
            Handler = handler;
            Runtime = runtime;
            Description = description;
            FunctionName = functionName;
            Construct = construct;
            Timeout = timeout;
        }
    }
}