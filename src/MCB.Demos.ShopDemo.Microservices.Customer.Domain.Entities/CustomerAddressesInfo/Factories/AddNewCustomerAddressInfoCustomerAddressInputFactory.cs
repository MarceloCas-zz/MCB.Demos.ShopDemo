using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories;

public sealed class AddNewCustomerAddressInfoCustomerAddressInputFactory
    : IAddNewCustomerAddressInfoCustomerAddressInputFactory
{
    // Public Methods
    public AddNewCustomerAddressInfoCustomerAddressInput Create(AddNewCustomerAddressInput parameter)
    {
        return new AddNewCustomerAddressInfoCustomerAddressInput(
            parameter.TenantId,
            parameter.CustomerAddressType,
            parameter.AddressValueObject,
            parameter.ExecutionUser,
            parameter.SourcePlatform
        );
    }
}