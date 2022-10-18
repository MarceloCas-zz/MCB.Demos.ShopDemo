using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;

public sealed record ChangeDefaultCustomerAddressInfoShippingAddressInput
    : InputBase
{
    // Properties
    public Guid CustomerAddressId { get; }

    // Constructors
    public ChangeDefaultCustomerAddressInfoShippingAddressInput(
        Guid tenantId,
        Guid customerAddressId,
        string executionUser,
        string sourcePlatform
    ) : base(tenantId, executionUser, sourcePlatform)
    {
        CustomerAddressId = customerAddressId;
    }
}