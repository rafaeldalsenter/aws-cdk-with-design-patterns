using AwsCdkWithDesignPatterns.Extensions;
using Flunt.Notifications;
using Flunt.Validations;

namespace AwsCdkWithDesignPatterns.Domain.Entities
{
    public class VpcNetwork : Notifiable<Notification>
    {
        private const int _minimumAzs = 1;

        internal VpcNetwork(string name, string cidr, int maxAzs)
        {
            Name = name;
            Cidr = cidr;
            MaxAzs = maxAzs;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrWhiteSpace(Name, "VpcNetwork.Name", "Name is required")
                .IsTrue(Cidr.IsValidCidr(), "VpcNetwork.Cidr", "CIDR is invalid")
                .IsGreaterOrEqualsThan(MaxAzs, _minimumAzs, "VpcNetwork.MaxAzs",
                    $"Max Azs must be greater or equal than {_minimumAzs}"));
        }

        public string Name { get; }
        public string Cidr { get; }
        public int MaxAzs { get; }
    }
}