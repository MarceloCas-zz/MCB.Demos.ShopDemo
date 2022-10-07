using MCB.Core.Domain.Entities.Abstractions;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Adapter;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainRepositories.Base.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainServices.Base
{
    public abstract class DomainServiceBase<TAggregationRoot>
        where TAggregationRoot : IAggregationRoot
    {
        // Properties
        protected IAdapter Adapter { get; }
        protected IDomainRepository<TAggregationRoot> DomainEntityRepository { get; }

        // Constructors
        protected DomainServiceBase(
            IAdapter adapter,
            IDomainRepository<TAggregationRoot> domainEntityRepository
        )
        {
            Adapter = adapter;
            DomainEntityRepository = domainEntityRepository;
        }
    }
}
