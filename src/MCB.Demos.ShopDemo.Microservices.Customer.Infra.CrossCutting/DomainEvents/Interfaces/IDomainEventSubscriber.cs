using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Observer;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Models.Base;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Interfaces;

public interface IDomainEventSubscriber
    : ISubscriber<DomainEventBase>
{
    IEnumerable<DomainEventBase> DomainEventCollection { get; }

    bool TryDequeue(out DomainEventBase? domainEvent);
}
