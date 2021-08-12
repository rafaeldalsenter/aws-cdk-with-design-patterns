# aws-cdk-with-design-patterns

☁ AWS CDK example with design patterns

This project aims to demonstrate the use of object-oriented language concepts in Infra as code. It contains domain, unit tests and some design patterns like Factory Method and Builder.

It uses AWS CDK library that allows creating Infra as code using C# and deploying via command line. More details:
- [AWS CDK features](https://aws.amazon.com/cdk/features/)
- [Getting started with the AWS CDK](https://docs.aws.amazon.com/cdk/latest/guide/getting_started.html)
- [Working with the AWS CDK in C#](https://docs.aws.amazon.com/cdk/latest/guide/work-with-cdk-csharp.html)

If you liked the project, please give a star! 🌟

| CodeFactor |
|:---:|
|[![CodeFactor](https://www.codefactor.io/repository/github/rafaeldalsenter/aws-cdk-with-design-patterns/badge?s=ccf1c724015f7f223250477195318fa1816b920b)](https://www.codefactor.io/repository/github/rafaeldalsenter/aws-cdk-with-design-patterns)|

## Domain layer

At the domain layer, there are two main items:
- LambdaFunctionDomain: Contains all properties necessary to create a AWS Lambda function, and specific rules can be created (for example, only allow Lambda functions in .NET Core 3.1).
- LambdaFunctionFactory: From the constructed domain, this class creates the corresponding AWS CDK object. It must be implemented in each Lambda Function you want to create.

## Getting Started

The main project contains the usage example, where two Lambda functions are created. The creation basically consists of implementing the LambdaFunctionFactory:

```csharp

public class ExampleFunction : LambdaFunctionFactory
{
    public ExampleFunction(Construct construct) : base(construct)
    {
    }

    protected override LambdaFunctionDomain FactoryMethod()
    {
        return new LambdaFunctionBuilder()
            .WithDescription("example description")
            .WithHandler("example.handler")
            .WithName("exampleFunctionName")
            .WithRuntime(new LambdaFunctionRuntimeDotnetCore31())
            .WithTimeout(TimeSpan.FromSeconds(10))
            .Build();
    }
}

```

Is ready! After creating this class, the Stack (DevelopmentStack) will already recognize it, as it will build all the objects that inherit from IFactory. Just run the command line to deploy:

```
cdk diff   // Compares the specified stack with the deployed stack or a local CloudFormation template
cdk deploy // Deploys the specified stack
```

## Limitations

Running the AWS CDK consists of [converting to an Javascript classes](https://aws.github.io/jsii/) (then a AWS CloudFormation template) and running. For this reason, unit tests only cover areas where there are no CDK object references (domain classes and extensions).







