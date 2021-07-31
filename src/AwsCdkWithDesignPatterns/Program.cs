using Amazon.CDK;

namespace AwsCdkExtensions
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new DevelopmentStack(app, "DevelopmentStack");
            app.Synth();
        }
    }
}