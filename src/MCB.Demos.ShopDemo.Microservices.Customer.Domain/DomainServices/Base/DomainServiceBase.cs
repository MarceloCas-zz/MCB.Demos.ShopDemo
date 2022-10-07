using MCB.Core.Domain.Entities.Abstractions;
using MCB.Core.Domain.Entities.DomainEntitiesBase;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Adapter;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Models;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainRepositories.Base.Abstractions;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications.Models;

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

        // Protected Methods
        protected async Task<bool> ValidateDomainEntityAndSendNotificationsAsync(DomainEntityBase domainEntityBase, CancellationToken cancellationToken)
        {
            foreach (var validationMessage in domainEntityBase.ValidationInfo.ValidationMessageCollection)
                await NotificationPublisher.PublishNotificationAsync(Adapter.Adapt<ValidationMessage, Notification>(validationMessage), cancellationToken);

            return domainEntityBase.ValidationInfo.IsValid;
        }
    }
}
