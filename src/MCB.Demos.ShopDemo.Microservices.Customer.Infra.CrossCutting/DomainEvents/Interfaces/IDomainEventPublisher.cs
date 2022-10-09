                                                                                                                                  using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Models.Base;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Interfaces
{
    public interface IDomainEventPublisher
    {
        Task PublishDomainEventAsync(DomainEventBase domainEvent, CancellationToken cancellationToken);
    }
}
