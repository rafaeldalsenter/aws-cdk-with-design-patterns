using System;
using Amazon.CDK;
using AwsCdkWithDesignPatterns.Extensions;
using Flunt.Notifications;

namespace AwsCdkWithDesignPatterns.Domain.Factories.Interfaces
{
    public abstract class AbstractFactory<TEntity, TAwsCdkResource> : IFactory
        where TEntity : Notifiable<Notification>
        where TAwsCdkResource : Resource
    {
        protected readonly Construct Construct;

        protected AbstractFactory(Construct construct)
        {
            Construct = construct;
        }

        public void Create()
        {
            var domain = FactoryMethod();

            if (!domain.IsValid)
                throw new Exception(domain.Notifications.ToStringConcat());

            CreateAwsCdkResource(domain);
        }

        internal abstract TAwsCdkResource CreateAwsCdkResource(TEntity domain);

        protected abstract TEntity FactoryMethod();
    }
}