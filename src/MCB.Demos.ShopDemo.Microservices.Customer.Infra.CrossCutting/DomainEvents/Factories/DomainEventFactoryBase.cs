using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Factories
{
    public abstract class DomainEventFactoryBase
    {
        // Properties
        protected IDateTimeProvider DateTimeProvider { get; }

        // Constructors
        protected DomainEventFactoryBase(IDateTimeProvider dateTimeProvider)
        {
            DateTimeProvider = dateTimeProvider;
        }
    }
}
