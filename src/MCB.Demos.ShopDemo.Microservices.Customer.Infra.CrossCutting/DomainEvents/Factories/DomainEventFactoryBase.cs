using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Models.Base.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Factories;

public abstract class DomainEventFactoryBase
{
    // Properties
    protected IDateTimeProvider DateTimeProvider { get; }

    // Constructors
    protected DomainEventFactoryBase(IDateTimeProvider dateTimeProvider)
    {
        DateTimeProvider = dateTimeProvider;
    }

    // Protected Methods
    protected (Guid id, DateTimeOffset timestamp, string domainEventType) GetBaseEventFields<TDomainEvent>() 
        where TDomainEvent : IDomainEvent
    {
        return (
            id: Guid.NewGuid(),
            timestamp: DateTimeProvider.GetDate(),
            domainEventType: typeof(TDomainEvent).FullName ?? string.Empty
        );
    }
}
