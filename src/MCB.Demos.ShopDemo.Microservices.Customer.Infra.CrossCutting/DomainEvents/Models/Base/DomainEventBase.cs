using MCB.Core.Domain.Entities.Abstractions;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Models.Base.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Models.Base;

public abstract record DomainEventBase 
    : IDomainEvent
{
    // Properties
    public Guid Id { get; }
    public DateTimeOffset Timestamp { get; }
    public string DomainEventType { get; }
    public IAggregationRoot AggregationRoot { get; }

    // Constructors
    protected DomainEventBase(Guid id, DateTimeOffset timestamp, string domainEventType, IAggregationRoot aggregationRoot)
    {
        Id = id;
        Timestamp = timestamp;
        DomainEventType = domainEventType;
        AggregationRoot = aggregationRoot;
    }
}
