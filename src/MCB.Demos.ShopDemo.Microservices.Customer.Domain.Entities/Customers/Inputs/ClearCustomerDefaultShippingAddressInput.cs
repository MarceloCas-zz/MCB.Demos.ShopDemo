using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;

public record ClearCustomerDefaultShippingAddressInput 
    : InputBase
{
    public ClearCustomerDefaultShippingAddressInput(
        Guid tenantId,
        string executionUser,
        string sourcePlatform
    ) : base(tenantId, executionUser, sourcePlatform)
    {
    }
}
