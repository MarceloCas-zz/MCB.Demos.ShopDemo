using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Models.Base;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents;

internal class DomainEventPublisher
    : IDomainEventPublisher
{
    // Fields
    private readonly IDomainEventPublisherInternal _DomainEventPublisherInternal;

    // Constructors
    internal DomainEventPublisher(IDomainEventPublisherInternal DomainEventPublisherInternal)
    {
        _DomainEventPublisherInternal = DomainEventPublisherInternal;
    }

    // Public Methods
    public Task PublishDomainEventAsync(DomainEventBase DomainEvent, CancellationToken cancellationToken)
    {
        return _DomainEventPublisherInternal.PublishAsync(DomainEvent, cancellationToken);
    }
}
