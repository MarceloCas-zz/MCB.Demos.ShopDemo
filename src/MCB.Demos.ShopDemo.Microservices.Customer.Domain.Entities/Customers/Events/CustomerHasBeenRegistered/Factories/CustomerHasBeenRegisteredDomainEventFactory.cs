using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Events.CustomerHasBeenRegistered;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Events.CustomerHasBeenRegistered.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Factories;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Events.CustomerHasBeenRegistered.Factories;

public class CustomerHasBeenRegisteredDomainEventFactory
    : DomainEventFactoryBase,
    ICustomerHasBeenRegisteredDomainEventFactory
{
    // Constructors
    public CustomerHasBeenRegisteredDomainEventFactory(
        IDateTimeProvider dateTimeProvider
    ) : base(dateTimeProvider)
    {
    }

    // Public Methods
    public CustomerHasBeenRegisteredDomainEvent Create(Customer parameter)
    {
        var (id, timestamp, domainEventType) = GetBaseEventFields<CustomerHasBeenRegisteredDomainEvent>();

        return new CustomerHasBeenRegisteredDomainEvent(
            id: id,
            timestamp: timestamp,
            domainEventType: domainEventType,
            parameter
        );
    }
}
