using Flunt.Notifications;
using Flunt.Validations;

namespace AwsCdkWithDesignPatterns.Domain.Entities
{
    public class VpcNetwork : Notifiable<Notification>
    {
        internal VpcNetwork(string name, string cidr, int maxAzs)
        {
            Name = name;
            Cidr = cidr;
            MaxAzs = maxAzs;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrWhiteSpace(Name, "VpcNetwork.Name", "Name is required"));
        }

        public string Name { get; }
        public string Cidr { get; }
        public int MaxAzs { get; }
    }
}