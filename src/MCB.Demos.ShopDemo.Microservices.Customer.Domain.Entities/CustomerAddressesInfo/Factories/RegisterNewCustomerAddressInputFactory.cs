using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories;

public sealed class RegisterNewCustomerAddressInputFactory
    : IRegisterNewCustomerAddressInputFactory
{
    // Public Methods
    public RegisterNewCustomerAddressInput Create(RegisterNewCustomerAddressInfoInput parameter)
    {
        return new RegisterNewCustomerAddressInput(
            parameter.TenantId,
            parameter.CustomerAddressType,
            parameter.AddressValueObject,
            parameter.ExecutionUser,
            parameter.SourcePlatform
        );
    }
    public RegisterNewCustomerAddressInput Create(AddNewCustomerAddressInfoCustomerAddressInput parameter)
    {
        return new RegisterNewCustomerAddressInput(
            parameter.TenantId,
            parameter.CustomerAddressType,
            parameter.AddressValueObject,
            parameter.ExecutionUser,
            parameter.SourcePlatform
        );
    }
}