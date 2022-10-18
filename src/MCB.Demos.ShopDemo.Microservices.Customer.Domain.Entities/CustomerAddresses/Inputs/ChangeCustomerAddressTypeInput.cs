using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Enums;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Inputs;

public sealed record ChangeCustomerAddressTypeInput
    : InputBase
{
    // Properties
    public CustomerAddressType CustomerAddressType { get; }

    // Constructors
    public ChangeCustomerAddressTypeInput(
        Guid tenantId,
        CustomerAddressType customerAddressType,
        string executionUser,
        string sourcePlatform
    ) : base(tenantId, executionUser, sourcePlatform)
    {
        CustomerAddressType = customerAddressType;
    }
}