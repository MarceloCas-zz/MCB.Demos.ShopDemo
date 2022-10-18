using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Inputs;

public sealed record RegisterNewCustomerAddressInput
    : InputBase
{
    // Properties
    public CustomerAddressType CustomerAddressType { get; }
    public AddressValueObject AddressValueObject { get; }

    // Constructors
    public RegisterNewCustomerAddressInput(
        Guid tenantId,
        CustomerAddressType customerAddressType,
        AddressValueObject addressValueObject,
        string executionUser,
        string sourcePlatform
    ) : base(tenantId, executionUser, sourcePlatform)
    {
        CustomerAddressType = customerAddressType;
        AddressValueObject = addressValueObject;
    }
}