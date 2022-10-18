using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.Factories;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.RegisterNewCustomer;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.RegisterNewCustomer.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Application.DependencyInjection;

public static class Bootstrapper
{
    // Public Methods
    public static void ConfigureDependencyInjection(IDependencyInjectionContainer dependencyInjectionContainer)
    {
        // Factories
        dependencyInjectionContainer.RegisterSingleton<IExternalEventFactory, ExternalEventFactory>();

        // Use Cases
        dependencyInjectionContainer.RegisterSingleton<IRegisterNewCustomerUseCase, RegisterNewCustomerUseCase>();
    }
}