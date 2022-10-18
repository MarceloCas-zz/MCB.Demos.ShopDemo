using MCB.Core.Domain.Abstractions.DomainEvents;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Adapter;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.RegisterNewCustomer.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.RegisterNewCustomer.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Services.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Services.Customers.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.RegisterNewCustomer;

internal class RegisterNewCustomerUseCase
    : UseCaseBase<RegisterNewCustomerUseCaseInput>,
    IRegisterNewCustomerUseCase
{
    // Fields
    private readonly ICustomerService _customerService;

    // Constructors
    internal RegisterNewCustomerUseCase(
        IDomainEventSubscriber domainEventSubscriber,
        IExternalEventFactory externalEventFactory,
        IAdapter adapter,
        ICustomerService customerService
    ) : base(domainEventSubscriber, externalEventFactory, adapter)
    {
        _customerService = customerService;
    }

    // Public Methods
    protected override Task<bool> ExecuteInternalAsync(RegisterNewCustomerUseCaseInput input, CancellationToken cancellationToken)
    {
        return _customerService.RegisterNewCustomerAsync(
            Adapter.Adapt<RegisterNewCustomerUseCaseInput, RegisterNewCustomerServiceInput>(input),
            cancellationToken
        );
    }
}