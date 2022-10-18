using MCB.Core.Domain.Entities.DomainEntitiesBase.Events;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Events.CustomerHasBeenRegistered;

public record CustomerHasBeenRegisteredDomainEvent
    : DomainEventBase
{
    public CustomerHasBeenRegisteredDomainEvent(
        Guid id,
        DateTimeOffset timestamp,
        string domainEventType,
        Customer customer
    ) : base(id, timestamp, domainEventType, customer)
    {
    }
}