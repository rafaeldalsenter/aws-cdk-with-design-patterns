using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;
using AwsCdkWithDesignPatterns.Domain.Builders.Interfaces;

namespace AwsCdkWithDesignPatterns.Domain.Builders
{
    public class LambdaFunctionBuilder : ILambdaFunctionBuilder
    {
        private Construct _construct;
        private string _description;
        private string _handler;
        private string _name;
        private Runtime _runtime;
        private Duration _timeout;

        public LambdaFunctionDomain Build()
        {
            return new(_handler, _construct, _runtime, _description, _name, _timeout);
        }

        public ILambdaFunctionBuilder WithHandler(string handler)
        {
            _handler = handler;
            return this;
        }

        public ILambdaFunctionBuilder WithRuntime(Runtime runtime)
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

        public ILambdaFunctionBuilder WithTimeout(Duration timeout)
        {
            _timeout = timeout;
            return this;
        }

        public ILambdaFunctionBuilder WithConstruct(Construct construct)
        {
            _construct = construct;
            return this;
        }
    }
}