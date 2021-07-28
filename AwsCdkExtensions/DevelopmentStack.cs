using System.Threading.Tasks;
using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;
using AwsCdkExtensions.Domain.Commands;
using MediatR;

namespace AwsCdkExtensions
{
    public class DevelopmentStack : Stack
    {
        internal DevelopmentStack(Construct scope, string id, IMediator mediator, IStackProps props = null) : base(scope, id, props)
        {
            Task.Run(() => mediator.Send(new CreateFunctionLambdaCommand(
                "hello.handler", Runtime.DOTNET_CORE_3_1, "description1", "functionname", Duration.Seconds(10), scope
            )));

            // new Function(this, "hellohandler", new FunctionProps()
            // {
            //     Runtime = Runtime.DOTNET_CORE_3_1,
            //     Handler = "hello.handler",
            //     Description = "Description",
            //     FunctionName = "FunctionName",
            //     Code = new AssetCode("lambda"),
            //     //Vpc = request.Vpc,
            //     Timeout = Duration.Seconds(10)
            // });
        }
    }
}