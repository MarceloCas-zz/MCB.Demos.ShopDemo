using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Models.Base;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Events.CustomerHasBeenRegistered
{
    public record CustomerHasBeenRegisteredDomainEvent
        : DomainEventBase
    {
        // Constructors
        public CustomerHasBeenRegisteredDomainEvent(
            IDateTimeProvider dateTimeProvider,
            Customer customer
        ) : base(dateTimeProvider, customer)
        {
        }
    }
}
