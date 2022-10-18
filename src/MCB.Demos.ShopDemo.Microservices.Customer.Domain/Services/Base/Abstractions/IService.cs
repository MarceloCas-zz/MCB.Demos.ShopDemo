using MCB.Core.Domain.Entities.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Services.Base.Abstractions;

public interface IService<TAggregationRoot>
    where TAggregationRoot : IAggregationRoot
{
}