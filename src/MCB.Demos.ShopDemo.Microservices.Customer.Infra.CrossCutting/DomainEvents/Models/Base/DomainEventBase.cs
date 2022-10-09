using MCB.Core.Domain.Entities.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Models.Base
{
    public abstract class DomainEventBase
    {
        // Properties
        public IAggregationRoot? AggregationRoot { get; protected set; }
    }
}
