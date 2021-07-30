using System;
using AwsCdkWithDesignPatterns.Domain.LambdaFunctionRuntimes;

namespace AwsCdkWithDesignPatterns.Domain
{
    public class LambdaFunctionDomain : AbstractDomain
    {
        internal LambdaFunctionDomain(string handler, ILambdaFunctionRuntime runtime, string description,
            string functionName, TimeSpan timeout)
        {
            SetHandler(handler);
            SetRuntime(runtime);
            SetDescription(description);
            SetFunctionName(functionName);
            SetTimeout(timeout);
        }

        public string Handler { get; private set; }
        public ILambdaFunctionRuntime Runtime { get; private set; }
        public string Description { get; private set; }
        public string FunctionName { get; private set; }
        public TimeSpan Timeout { get; private set; }

        private void SetTimeout(TimeSpan timeout)
        {
            Timeout = timeout;
        }

        private void SetHandler(string handler)
        {
            if (string.IsNullOrWhiteSpace(handler))
            {
                AddError("Deve conter a Handler da função lambda");
                return;
            }

            Handler = handler;
        }

        private void SetRuntime(ILambdaFunctionRuntime runtime)
        {
            if (runtime is not LambdaFunctionRuntimeDotnetCore31)
            {
                AddError("Somente é permitido funções lambda em .NET Core 3.1");
                return;
            }

            Runtime = runtime;
        }

        private void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                AddError("Deve conter a descrição da função lambda");
                return;
            }

            Description = description;
        }

        private void SetFunctionName(string functionName)
        {
            if (string.IsNullOrWhiteSpace(functionName))
            {
                AddError("Deve conter o nome da função lambda");
                return;
            }

            FunctionName = functionName;
        }
    }
}