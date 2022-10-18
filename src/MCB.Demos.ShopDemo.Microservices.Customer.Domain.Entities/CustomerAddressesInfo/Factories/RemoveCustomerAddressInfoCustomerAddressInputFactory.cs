using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories;

public sealed class RemoveCustomerAddressInfoCustomerAddressInputFactory
    : IRemoveCustomerAddressInfoCustomerAddressInputFactory
{
    // Public Methods
    public RemoveCustomerAddressInfoCustomerAddressInput Create(RemoveCustomerAddressInput parameter)
    {
        return new RemoveCustomerAddressInfoCustomerAddressInput(
            parameter.TenantId,
            parameter.CustomerAddressId,
            parameter.ExecutionUser,
            parameter.SourcePlatform
        );
    }
}