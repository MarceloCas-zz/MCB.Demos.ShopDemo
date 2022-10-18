using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;

public sealed record RemoveCustomerAddressInfoCustomerAddressInput
    : InputBase
{
    // Properties
    public Guid CustomerAddressId { get; }

    // Constructors
    public RemoveCustomerAddressInfoCustomerAddressInput(
        Guid tenantId,
        Guid customerAddressId,
        string executionUser,
        string sourcePlatform
    ) : base(tenantId, executionUser, sourcePlatform)
    {
        CustomerAddressId = customerAddressId;
    }
}