using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories;

public sealed class ChangeCustomerAddressInfoCustomerAddressInputFactory
    : IChangeCustomerAddressInfoCustomerAddressInputFactory
{
    // Public Methods
    public ChangeCustomerAddressInfoCustomerAddressInput Create(Customers.Inputs.ChangeCustomerAddressInput parameter)
    {
        return new ChangeCustomerAddressInfoCustomerAddressInput(
            parameter.TenantId,
            parameter.CustomerAddressId,
            parameter.CustomerAddressType,
            parameter.AddressValueObject,
            parameter.ExecutionUser,
            parameter.SourcePlatform
        );
    }
}