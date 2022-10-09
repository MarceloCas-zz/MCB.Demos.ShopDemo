using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Models.Base;
using System.Collections.Concurrent;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents
{
    internal class DomainEventSubscriber
        : IDomainEventSubscriber
    {
        // Fields
        private readonly ConcurrentBag<DomainEventBase> _domainEventCollection;

        // Properties
        public IEnumerable<DomainEventBase> DomainEventCollection => _domainEventCollection.AsEnumerable();

        // Constructors
        internal DomainEventSubscriber()
        {
            _domainEventCollection = new ConcurrentBag<DomainEventBase>();
        }

        // Public Methods
        public Task HandlerAsync(DomainEventBase subject, CancellationToken cancellationToken)
        {
            _domainEventCollection.Add(subject);
            return Task.CompletedTask;
        }
    }
}
