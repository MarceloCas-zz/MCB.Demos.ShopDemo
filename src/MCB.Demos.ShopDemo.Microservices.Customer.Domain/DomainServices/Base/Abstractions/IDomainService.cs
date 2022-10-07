using MCB.Core.Domain.Entities.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainServices.Base.Abstractions
{
    public interface IDomainService<TAggregationRoot>
        where TAggregationRoot : IAggregationRoot
    {
    }
}
