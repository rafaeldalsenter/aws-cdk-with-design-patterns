using System;
using System.Linq;
using Amazon.CDK;
using AwsCdkWithDesignPatterns.Domain.Factories.Interfaces;

namespace AwsCdkExtensions
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new DevelopmentStack(app, "TestStack");
            
            app.Synth();
        }
    }
}