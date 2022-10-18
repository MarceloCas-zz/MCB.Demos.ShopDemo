using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;

public sealed record ClearDefaultCustomerAddressInfoShippingAddressInput
    : InputBase
{
    // Constructors
    public ClearDefaultCustomerAddressInfoShippingAddressInput(
        Guid tenantId,
        string executionUser,
        string sourcePlatform
    ) : base(tenantId, executionUser, sourcePlatform)
    {
    }
}