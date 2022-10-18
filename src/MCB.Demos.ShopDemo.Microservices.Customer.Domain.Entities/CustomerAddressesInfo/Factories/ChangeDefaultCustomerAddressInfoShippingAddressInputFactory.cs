using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories;

public sealed class ChangeDefaultCustomerAddressInfoShippingAddressInputFactory
    : IChangeDefaultCustomerAddressInfoShippingAddressInputFactory
{
    // Public Methods
    public ChangeDefaultCustomerAddressInfoShippingAddressInput Create(ChangeCustomerDefaultShippingAddressInput parameter)
    {
        return new ChangeDefaultCustomerAddressInfoShippingAddressInput(
            parameter.TenantId,
            parameter.CustomerAddressId,
            parameter.ExecutionUser,
            parameter.SourcePlatform
        );
    }
}