using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Factories;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Factories;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Email.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Email.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Email.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Email.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.DependencyInjection;

public static class Bootstrapper
{
    // Public Methods
    public static void ConfigureDependencyInjection(IDependencyInjectionContainer dependencyInjectionContainer)
    {
        ConfigureDependencyInjectionForCustomerAddress(dependencyInjectionContainer);
        ConfigureDependencyInjectionForCustomerAddressInfo(dependencyInjectionContainer);
        ConfigureDependencyInjectionForCustomer(dependencyInjectionContainer);
        ConfigureDependencyInjectionForAddressValueObjects(dependencyInjectionContainer);
        ConfigureDependencyInjectionForEmailValueObjects(dependencyInjectionContainer);
    }

    // Private Methods
    private static void ConfigureDependencyInjectionForCustomerAddress(IDependencyInjectionContainer dependencyInjectionContainer)
    {
        // Factories
        dependencyInjectionContainer.RegisterSingleton<IChangeCustomerFullAddressInfoInputFactory, ChangeCustomerFullAddressInfoInputFactory>();
        dependencyInjectionContainer.RegisterSingleton<ICustomerAddressFactory, CustomerAddressFactory>();

        // Specifications
        dependencyInjectionContainer.RegisterSingleton<ICustomerAddressSpecifications, CustomerAddressSpecifications>();

        // Validators
        dependencyInjectionContainer.RegisterSingleton<CustomerAddresses.Validators.Interfaces.IChangeCustomerAddressInputShouldBeValidValidator, CustomerAddresses.Validators.ChangeCustomerAddressInputShouldBeValidValidator>();
        dependencyInjectionContainer.RegisterSingleton<IChangeCustomerAddressTypeInputShouldBeValidValidator, ChangeCustomerAddressTypeInputShouldBeValidValidator>();
        dependencyInjectionContainer.RegisterSingleton<IChangeCustomerFullAddressInfoInputShouldBeValidValidator, ChangeCustomerFullAddressInfoInputShouldBeValidValidator>();
        dependencyInjectionContainer.RegisterSingleton<ICustomerAddressShouldBeValidValidator, CustomerAddressShouldBeValidValidator>();
        dependencyInjectionContainer.RegisterSingleton<IRegisterNewCustomerAddressInputShouldBeValidValidator, RegisterNewCustomerAddressInputShouldBeValidValidator>();
    }
    private static void ConfigureDependencyInjectionForCustomerAddressInfo(IDependencyInjectionContainer dependencyInjectionContainer)
    {
        // Factories
        dependencyInjectionContainer.RegisterSingleton<IAddNewCustomerAddressInfoCustomerAddressInputFactory, AddNewCustomerAddressInfoCustomerAddressInputFactory>();
        dependencyInjectionContainer.RegisterSingleton<IChangeCustomerAddressInfoCustomerAddressInputFactory, ChangeCustomerAddressInfoCustomerAddressInputFactory>();
        dependencyInjectionContainer.RegisterSingleton<IChangeDefaultCustomerAddressInfoShippingAddressInputFactory, ChangeDefaultCustomerAddressInfoShippingAddressInputFactory>();
        dependencyInjectionContainer.RegisterSingleton<IClearDefaultCustomerAddressInfoShippingAddressInputFactory, ClearDefaultCustomerAddressInfoShippingAddressInputFactory>();
        dependencyInjectionContainer.RegisterSingleton<ICustomerAddressInfoFactory, CustomerAddressInfoFactory>();
        dependencyInjectionContainer.RegisterSingleton<IRegisterNewCustomerAddressInputFactory, RegisterNewCustomerAddressInputFactory>();
        dependencyInjectionContainer.RegisterSingleton<IRemoveCustomerAddressInfoCustomerAddressInputFactory, RemoveCustomerAddressInfoCustomerAddressInputFactory>();

        // Specifications
        dependencyInjectionContainer.RegisterSingleton<ICustomerAddressInfoSpecifications, CustomerAddressInfoSpecifications>();

        // Validators
        dependencyInjectionContainer.RegisterSingleton<IAddNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator, AddNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator>();
        dependencyInjectionContainer.RegisterSingleton<IChangeCustomerAddressInfoCustomerAddressInputShouldBeValidValidator, ChangeCustomerAddressInfoCustomerAddressInputShouldBeValidValidator>();
        dependencyInjectionContainer.RegisterSingleton<IChangeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator, ChangeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator>();
        dependencyInjectionContainer.RegisterSingleton<IClearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator, ClearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator>();
        dependencyInjectionContainer.RegisterSingleton<ICustomerAddressInfoShouldHaveCustomerAddressValidator, CustomerAddressInfoShouldHaveCustomerAddressValidator>();
        dependencyInjectionContainer.RegisterSingleton<IRegisterNewCustomerAddressInfoInputShouldBeValidValidator, RegisterNewCustomerAddressInfoInputShouldBeValidValidator>();
        dependencyInjectionContainer.RegisterSingleton<IRemoveCustomerAddressInfoCustomerAddressInputShouldBeValidValidator, RemoveCustomerAddressInfoCustomerAddressInputShouldBeValidValidator>();
    }
    private static void ConfigureDependencyInjectionForCustomer(IDependencyInjectionContainer dependencyInjectionContainer)
    {
        // Factories
        dependencyInjectionContainer.RegisterSingleton<ICustomerFactory, CustomerFactory>();

        // Specifications
        dependencyInjectionContainer.RegisterSingleton<ICustomerSpecifications, CustomerSpecifications>();

        // Validators
        dependencyInjectionContainer.RegisterSingleton<IAddNewCustomerAddressInputShouldBeValidValidator, AddNewCustomerAddressInputShouldBeValidValidator>();
        dependencyInjectionContainer.RegisterSingleton<Customers.Validators.Interfaces.IChangeCustomerAddressInputShouldBeValidValidator, Customers.Validators.ChangeCustomerAddressInputShouldBeValidValidator>();
        dependencyInjectionContainer.RegisterSingleton<IChangeCustomerDefaultShippingAddressInputShouldBeValidValidator, ChangeCustomerDefaultShippingAddressInputShouldBeValidValidator>();
        dependencyInjectionContainer.RegisterSingleton<IChangeCustomerNameInputShouldBeValidValidator, ChangeCustomerNameInputShouldBeValidValidator>();
        dependencyInjectionContainer.RegisterSingleton<IClearCustomerDefaultShippingAddressInputShouldBeValidValidator, ClearCustomerDefaultShippingAddressInputShouldBeValidValidator>();
        dependencyInjectionContainer.RegisterSingleton<IRegisterNewCustomerInputShouldBeValidValidator, RegisterNewCustomerInputShouldBeValidValidator>();
        dependencyInjectionContainer.RegisterSingleton<IRemoveCustomerAddressInputShouldBeValidValidator, RemoveCustomerAddressInputShouldBeValidValidator>();
    }
    private static void ConfigureDependencyInjectionForAddressValueObjects(IDependencyInjectionContainer dependencyInjectionContainer)
    {
        // Specifications
        dependencyInjectionContainer.RegisterSingleton<IAddressValueObjectSpecifications, AddressValueObjectSpecifications>();

        // Validators
        dependencyInjectionContainer.RegisterSingleton<IAddressValueObjectShouldBeValidValidator, AddressValueObjectShouldBeValidValidator>();
    }
    private static void ConfigureDependencyInjectionForEmailValueObjects(IDependencyInjectionContainer dependencyInjectionContainer)
    {
        // Specifications
        dependencyInjectionContainer.RegisterSingleton<IEmailValueObjectSpecifications, EmailValueObjectSpecifications>();

        // Validators
        dependencyInjectionContainer.RegisterSingleton<IEmailValueObjectShouldBeValidValidator, EmailValueObjectShouldBeValidValidator>();
    }
}