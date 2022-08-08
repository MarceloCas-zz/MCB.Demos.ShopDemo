using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs
{
    public record ChangeDefaultCustomerAddressInfoShippingAddressInput
        : InputBase
    {
        // Properties
        public CustomerAddress CustomerAddress { get; set; }

        // Constructors
        public ChangeDefaultCustomerAddressInfoShippingAddressInput(
            Guid tenantId,
            CustomerAddress customerAddress,
            string executionUser, 
            string sourcePlatform
        ) : base(tenantId, executionUser, sourcePlatform)
        {
            CustomerAddress = customerAddress;
        }
    }
}
