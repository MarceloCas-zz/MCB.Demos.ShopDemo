using MCB.Core.Domain.Entities.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Models.Base.Abstractions;

public interface IDomainEvent
{
    Guid Id { get; }
    DateTimeOffset Timestamp { get; }
    string DomainEventType { get; }
    IAggregationRoot AggregationRoot { get; }
}