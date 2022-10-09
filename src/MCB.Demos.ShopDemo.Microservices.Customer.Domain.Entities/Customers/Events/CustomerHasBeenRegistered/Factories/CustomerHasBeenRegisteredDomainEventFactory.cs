using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Events.CustomerHasBeenRegistered.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Factories;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Events.CustomerHasBeenRegistered.Factories
{
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
            return new CustomerHasBeenRegisteredDomainEvent(DateTimeProvider, parameter);
        }
    }
}
