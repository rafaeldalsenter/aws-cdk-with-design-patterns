﻿using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;

namespace AwsCdkExtensions.Domain
{
    public class FunctionLambdaDomain : AbstractDomain
    {
        public string Handler { get; private set; }
        public Runtime Runtime { get; private set; }
        public string Description { get; private set; }
        public string FunctionName { get; private set; }
        public Duration Timeout { get; private set; }

        public FunctionLambdaDomain(string handler, Runtime runtime, string description, string functionName, Duration timeout)
        {
            SetHandler(handler);
            SetRuntime(runtime);
            SetDescription(description);
            SetFunctionName(functionName);
            SetTimeout(timeout);
        }

        private void SetTimeout(Duration timeout)
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

        private void SetRuntime(Runtime runtime)
        {
            if (!runtime.Equals(Runtime.DOTNET_CORE_3_1))
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