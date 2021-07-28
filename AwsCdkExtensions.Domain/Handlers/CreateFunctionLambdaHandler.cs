using System;
using System.Threading;
using System.Threading.Tasks;
using Amazon.CDK.AWS.Lambda;
using AwsCdkExtensions.Domain.Commands;
using AwsCdkExtensions.Domain.Responses;
using MediatR;

namespace AwsCdkExtensions.Domain.Handlers
{
    public class CreateFunctionLambdaHandler : IRequestHandler<CreateFunctionLambdaCommand, CreateFunctionLambdaResponse>
    {
        public Task<CreateFunctionLambdaResponse> Handle(CreateFunctionLambdaCommand request, CancellationToken cancellationToken)
        {
            var functionLambda = new FunctionLambdaDomain(request.Handler,
                request.Runtime,
                request.Description,
                request.FunctionName,
                request.Timeout);

            if (!functionLambda.IsValid())
            {
                return Task.FromResult(new CreateFunctionLambdaResponse
                {
                    ErrorMessages = functionLambda.ErrorMessages
                });
            }
            
            var function = new Function(request.Construct, request.FunctionName, new FunctionProps()
            {
                Runtime = request.Runtime,
                Handler = request.Handler,
                Description = request.Description,
                FunctionName = request.FunctionName,
                Timeout = request.Timeout
            });
            
            return Task.FromResult(new CreateFunctionLambdaResponse
            {
                Function = function
            });
        }
    }
}