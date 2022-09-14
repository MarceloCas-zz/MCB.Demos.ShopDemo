using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs
{
    public record ChangeDefaultCustomerAddressInfoShippingAddressInput
        : InputBase
    {
        // Properties
        public Guid CustomerAddressId { get; set; }

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
}
