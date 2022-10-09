using MCB.Core.Domain.Entities.Abstractions;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Models.Base;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Models
{
    public class DomainEvent<TAggregationRoot>
        : DomainEventBase
        where TAggregationRoot : IAggregationRoot
    {
    }
}
