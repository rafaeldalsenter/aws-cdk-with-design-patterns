namespace AwsCdkWithDesignPatterns.Extensions.Tests.Objects
{
    internal interface IBird
    {
    }

    internal class Hawk : IBird
    {
    }

    internal class Owl : IBird
    {
    }

    internal interface IAmphibian
    {
    }

    internal abstract class Frogs : IAmphibian
    {
    }

    internal interface IInsect
    {
    }

    internal interface IFlyers : IInsect
    {
    }

    internal class Dog
    {
    }
}