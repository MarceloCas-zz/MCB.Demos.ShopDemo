using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;

public sealed record ChangeCustomerAddressInput
    : InputBase
{
    // Properties
    public Guid CustomerAddressId { get; }
    public CustomerAddressType CustomerAddressType { get; }
    public AddressValueObject AddressValueObject { get; }

    // Constructors
    public ChangeCustomerAddressInput(
        Guid tenantId,
        Guid customerAddressId,
        CustomerAddressType customerAddressType,
        AddressValueObject addressValueObject,
        string executionUser,
        string sourcePlatform
    ) : base(tenantId, executionUser, sourcePlatform)
    {
        CustomerAddressId = customerAddressId;
        CustomerAddressType = customerAddressType;
        AddressValueObject = addressValueObject;
    }
}