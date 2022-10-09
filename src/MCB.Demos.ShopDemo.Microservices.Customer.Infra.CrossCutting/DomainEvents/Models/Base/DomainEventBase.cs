using MCB.Core.Domain.Entities.Abstractions;
using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Models.Base.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Models.Base
{
    public abstract record DomainEventBase 
        : IDomainEvent
    {
        // Properties
        public Guid Id { get; }
        public DateTimeOffset Timestamp { get; }
        public string DomainEventType { get; }
        public IAggregationRoot AggregationRoot { get; }

        // Constructors
        protected DomainEventBase(
            IDateTimeProvider dateTimeProvider,
            IAggregationRoot aggregationRoot
        )
        {
            Id = Guid.NewGuid();
            Timestamp = dateTimeProvider.GetDate();
            DomainEventType = aggregationRoot.GetType().FullName ?? string.Empty;
            AggregationRoot = aggregationRoot;
        }
    }
}
