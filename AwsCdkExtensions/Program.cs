using System;
using Amazon.CDK;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace AwsCdkExtensions
{
    class Program
    {
        public static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            var app = new App();
            new DevelopmentStack(app, "TestStack", serviceProvider.GetService<IMediator>());

            app.Synth();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(Program));
        }
    }
}