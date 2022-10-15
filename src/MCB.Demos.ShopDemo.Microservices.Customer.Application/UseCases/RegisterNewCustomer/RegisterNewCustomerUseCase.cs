using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Adapter;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.RegisterNewCustomer.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.RegisterNewCustomer.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Services.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Services.Customers.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Interfaces;

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
        IAdapter adapter,
        ICustomerService customerService
    ) : base(domainEventSubscriber, adapter)
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
