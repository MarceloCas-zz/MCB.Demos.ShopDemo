using Mapster;
using MCB.Core.Domain.Abstractions.DomainEvents;
using MCB.Core.Infra.CrossCutting.Abstractions.Serialization;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Adapter;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.Base.Input;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Events.CustomerHasBeenRegistered;
using MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.V1.Events.CustomerHasBeenRegistered;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.Base;

public abstract class UseCaseBase<TInput>
    : IUseCase<TInput>
    where TInput : UseCaseInputBase
{
    // Fields
    private readonly IDomainEventSubscriber _domainEventSubscriber;

    // Properties
    protected IAdapter Adapter { get; }

    // Constructors
    protected UseCaseBase(
        IDomainEventSubscriber domainEventSubscriber,
        IAdapter adapter
    )
    {
        _domainEventSubscriber = domainEventSubscriber;
        Adapter = adapter;
    }

    // Public Methods
    public async Task<bool> ExecuteAsync(TInput input, CancellationToken cancellationToken)
    {
        if (!await ExecuteInternalAsync(input, cancellationToken))
            return false;

        return await PublishDomainEventsToExternalBusAsync(cancellationToken);
    }

    // Protected Abstract Methods
    protected abstract Task<bool> ExecuteInternalAsync(TInput input, CancellationToken cancellationToken);

    // Private Methods
    private async Task<bool> PublishDomainEventsToExternalBusAsync(CancellationToken cancellationToken)
    {
        foreach (var domainEventBase in _domainEventSubscriber.DomainEventCollection)
        {
            if (domainEventBase is null)
                continue;

            var externalEvent = default(EventBase);

            if(domainEventBase is CustomerHasBeenRegisteredDomainEvent customerHasBeenRegisteredDomainEvent)
                externalEvent = Adapter.Adapt<CustomerHasBeenRegisteredDomainEvent, CustomerHasBeenRegisteredEvent>(customerHasBeenRegisteredDomainEvent);
        }

        await Task.Delay(1);

        return true;
    }
}
