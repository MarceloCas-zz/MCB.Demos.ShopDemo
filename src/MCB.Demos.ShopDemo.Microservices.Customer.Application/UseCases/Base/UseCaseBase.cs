﻿using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Adapter;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.Base.Input;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Models.Base;

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
        while (_domainEventSubscriber.TryDequeue(out DomainEventBase? domainEventBase))
        {
            if (domainEventBase is null)
                continue;

        }

        await Task.Delay(1);

        return true;
    }
}