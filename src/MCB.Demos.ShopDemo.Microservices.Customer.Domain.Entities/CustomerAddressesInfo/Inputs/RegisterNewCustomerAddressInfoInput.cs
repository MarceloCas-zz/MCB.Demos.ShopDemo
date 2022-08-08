using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs
{
    public record RegisterNewCustomerAddressInfoInput
        : InputBase
    {
        // Constructors
        public RegisterNewCustomerAddressInfoInput(
            Guid tenantId, 
            string executionUser, 
            string sourcePlatform
        ) : base(tenantId, executionUser, sourcePlatform)
        {
        }
    }
}
