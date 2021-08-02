using System;
using AwsCdkWithDesignPatterns.Domain.Entities.LambdaFunctionRuntimes;
using Flunt.Notifications;
using Flunt.Validations;

namespace AwsCdkWithDesignPatterns.Domain.Entities
{
    public class LambdaFunctionDomain : Notifiable<Notification>
    {
        internal LambdaFunctionDomain(string handler, ILambdaFunctionRuntime runtime, string description,
            string functionName, TimeSpan timeout)
        {
            Handler = handler;
            Runtime = runtime;
            Description = description;
            FunctionName = functionName;
            Timeout = timeout;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrWhiteSpace(Handler, "LambdaFunctionDomain.Handler", "Handler is required")
                .IsNotNullOrWhiteSpace(Description, "LambdaFunctionDomain.Description", "Description is required")
                .IsNotNullOrWhiteSpace(FunctionName, "LambdaFunctionDomain.FunctionName", "FunctionName is required")
                .IsTrue(runtime is LambdaFunctionRuntimeDotnetCore31, "LambdaFunctionDomain.Runtime",
                    "FunctionName must be .NET Core 3.1")
            );
        }

        public string Handler { get; }
        public ILambdaFunctionRuntime Runtime { get; }
        public string Description { get; }
        public string FunctionName { get; }
        public TimeSpan Timeout { get; }
    }
}