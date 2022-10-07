using MCB.Core.Domain.Entities.Abstractions;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Adapter;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainRepositories.Base.Abstractions;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainServices.Base
{
    public abstract class DomainServiceBase<TAggregationRoot>
        where TAggregationRoot : IAggregationRoot
    {
        // Properties
        protected INotificationPublisher NotificationPublisher { get; }
        protected IAdapter Adapter { get; }
        protected IDomainRepository<TAggregationRoot> DomainEntityRepository { get; }

        // Constructors
        protected DomainServiceBase(
            INotificationPublisher notificationPublisher,
            IAdapter adapter,
            IDomainRepository<TAggregationRoot> domainEntityRepository
        )
        {
            NotificationPublisher = notificationPublisher;
            Adapter = adapter;
            DomainEntityRepository = domainEntityRepository;
        }
    }
}
