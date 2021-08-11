using System;
using AwsCdkWithDesignPatterns.Domain.Entities.LambdaFunctionRuntimes;
using Flunt.Notifications;
using Flunt.Validations;

namespace AwsCdkWithDesignPatterns.Domain.Entities
{
    public class LambdaFunction : Notifiable<Notification>
    {
        private const int _maxSecondsTimeout = 60;

        internal LambdaFunction(string handler, ILambdaFunctionRuntime runtime, string description,
            string functionName, TimeSpan timeout)
        {
            Handler = handler;
            Runtime = runtime;
            Description = description;
            FunctionName = functionName;
            Timeout = timeout;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrWhiteSpace(Handler, "LambdaFunction.Handler", "Handler is required")
                .IsNotNullOrWhiteSpace(Description, "LambdaFunction.Description", "Description is required")
                .IsNotNullOrWhiteSpace(FunctionName, "LambdaFunction.FunctionName", "FunctionName is required")
                .IsTrue(Timeout.Seconds <= _maxSecondsTimeout, "LambdaFunction.Timeout",
                    $"Timeout cannot exceed {_maxSecondsTimeout} seconds")
                .IsTrue(Runtime is LambdaFunctionRuntimeDotnetCore31, "LambdaFunction.Runtime",
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