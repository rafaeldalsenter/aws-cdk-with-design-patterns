using System;
using AwsCdkWithDesignPatterns.Domain.Builders.Interfaces;
using AwsCdkWithDesignPatterns.Domain.Entities;
using AwsCdkWithDesignPatterns.Domain.Entities.LambdaFunctionRuntimes;

namespace AwsCdkWithDesignPatterns.Domain.Builders
{
    public class LambdaFunctionBuilder : ILambdaFunctionBuilder
    {
        private string _description;
        private string _handler;
        private string _name;
        private ILambdaFunctionRuntime _runtime;
        private TimeSpan _timeout;

        public LambdaFunctionDomain Build()
        {
            return new(_handler, _runtime, _description, _name, _timeout);
        }

        public ILambdaFunctionBuilder WithHandler(string handler)
        {
            _handler = handler;
            return this;
        }

        public ILambdaFunctionBuilder WithRuntime(ILambdaFunctionRuntime runtime)
        {
            _runtime = runtime;
            return this;
        }

        public ILambdaFunctionBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public ILambdaFunctionBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ILambdaFunctionBuilder WithTimeout(TimeSpan timeout)
        {
            _timeout = timeout;
            return this;
        }
    }
}