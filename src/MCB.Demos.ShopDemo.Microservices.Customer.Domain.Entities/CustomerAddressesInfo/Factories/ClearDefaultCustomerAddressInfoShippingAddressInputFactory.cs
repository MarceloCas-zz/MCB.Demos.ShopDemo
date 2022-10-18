using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories;

public sealed class ClearDefaultCustomerAddressInfoShippingAddressInputFactory
    : IClearDefaultCustomerAddressInfoShippingAddressInputFactory
{
    // Public Methods
    public ClearDefaultCustomerAddressInfoShippingAddressInput Create(ClearCustomerDefaultShippingAddressInput parameter)
    {
        return new ClearDefaultCustomerAddressInfoShippingAddressInput(
            parameter.TenantId,
            parameter.ExecutionUser,
            parameter.SourcePlatform
        );
    }
}