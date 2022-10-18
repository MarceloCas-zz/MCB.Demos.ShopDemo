using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Inputs;

public sealed record ChangeCustomerAddressInput
    : InputBase
{
    // Properties
    public AddressValueObject AddressValueObject { get; }

    // Constructors
    public ChangeCustomerAddressInput(
        Guid tenantId,
        AddressValueObject addressValueObject,
        string executionUser,
        string sourcePlatform
    ) : base(tenantId, executionUser, sourcePlatform)
    {
        AddressValueObject = addressValueObject;
    }
}