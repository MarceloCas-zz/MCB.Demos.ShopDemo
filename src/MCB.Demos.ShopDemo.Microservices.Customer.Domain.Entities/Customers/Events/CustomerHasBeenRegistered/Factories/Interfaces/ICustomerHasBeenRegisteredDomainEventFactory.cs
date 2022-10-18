using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Factory;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Events.CustomerHasBeenRegistered.Factories.Interfaces;

public interface ICustomerHasBeenRegisteredDomainEventFactory
    : IFactoryWithParameter<CustomerHasBeenRegisteredDomainEvent, Customer>
{
}