using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;

public sealed record AddNewCustomerAddressInput
    : InputBase
{
    // Properties
    public CustomerAddressType CustomerAddressType { get; }
    public AddressValueObject AddressValueObject { get; }

    // Constructors
    public AddNewCustomerAddressInput(
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