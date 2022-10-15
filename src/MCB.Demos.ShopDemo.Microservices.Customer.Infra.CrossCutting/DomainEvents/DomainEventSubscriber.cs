using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Models.Base;
using System.Collections.Concurrent;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents;

internal class DomainEventSubscriber
    : IDomainEventSubscriber
{
    // Fields
    private readonly ConcurrentQueue<DomainEventBase> _domainEventCollection;

    // Properties
    public IEnumerable<DomainEventBase> DomainEventCollection => _domainEventCollection.AsEnumerable();

    // Constructors
    internal DomainEventSubscriber()
    {
        _domainEventCollection = new ConcurrentQueue<DomainEventBase>();
    }

    // Public Methods
    public Task HandlerAsync(DomainEventBase subject, CancellationToken cancellationToken)
    {
        _domainEventCollection.Enqueue(subject);
        return Task.CompletedTask;
    }
    public bool TryDequeue(out DomainEventBase? domainEvent)
    {
        if (_domainEventCollection.TryDequeue(out DomainEventBase? domainEventBase))
        {
            domainEvent = domainEventBase;
            return true;
        }
        else
        {
            domainEvent = null;
            return false;
        }
    }
}
