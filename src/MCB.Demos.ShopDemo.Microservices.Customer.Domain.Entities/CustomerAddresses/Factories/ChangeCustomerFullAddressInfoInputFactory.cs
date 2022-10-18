using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Factories;

public sealed class ChangeCustomerFullAddressInfoInputFactory
    : IChangeCustomerFullAddressInfoInputFactory
{
    // Public Methods
    public ChangeCustomerFullAddressInfoInput Create(ChangeCustomerAddressInfoCustomerAddressInput parameter)
    {
        return new ChangeCustomerFullAddressInfoInput(
            parameter.TenantId,
            parameter.CustomerAddressType,
            parameter.AddressValueObject,
            parameter.ExecutionUser,
            parameter.SourcePlatform
        );
    }
}