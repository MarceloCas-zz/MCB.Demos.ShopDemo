using MCB.Core.Domain.Entities.Abstractions.DomainEvents;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Adapter;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Events.CustomerHasBeenRegistered;
using MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.V1.Events.CustomerHasBeenRegistered;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Application.Factories;

internal class ExternalEventFactory
    : IExternalEventFactory
{
    public EventBase? Create((IAdapter adapter, IDomainEvent domainEvent) parameter)
    {
        if (parameter.domainEvent is CustomerHasBeenRegisteredDomainEvent domainEvent)
            return parameter.adapter.Adapt<CustomerHasBeenRegisteredEvent>(domainEvent);
        else
            return null;
    }
}