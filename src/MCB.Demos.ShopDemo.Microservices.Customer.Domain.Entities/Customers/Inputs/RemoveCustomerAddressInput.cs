using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;

public sealed record RemoveCustomerAddressInput
    : InputBase
{
    public Guid CustomerAddressId { get; }

    public RemoveCustomerAddressInput(
        Guid tenantId,
        Guid customerAddressId,
        string executionUser,
        string sourcePlatform
    ) : base(tenantId, executionUser, sourcePlatform)
    {
        CustomerAddressId = customerAddressId;
    }
}
