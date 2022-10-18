using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;

public sealed record ClearCustomerDefaultShippingAddressInput
    : InputBase
{
    // Constructors
    public ClearCustomerDefaultShippingAddressInput(
        Guid tenantId,
        string executionUser,
        string sourcePlatform
    ) : base(tenantId, executionUser, sourcePlatform)
    {
    }
}