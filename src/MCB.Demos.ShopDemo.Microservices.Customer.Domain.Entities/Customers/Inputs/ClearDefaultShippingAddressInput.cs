using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs
{
    public record ClearDefaultShippingAddressInput 
        : InputBase
    {
        public ClearDefaultShippingAddressInput(
            Guid tenantId,
            string executionUser,
            string sourcePlatform
        ) : base(tenantId, executionUser, sourcePlatform)
        {
        }
    }
}
