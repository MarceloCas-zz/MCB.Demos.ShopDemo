using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs
{
    public record ChangeCustomerDefaultShippingAddressInput
        : InputBase
    {
        public CustomerAddress CustomerAddress { get; }

        public ChangeCustomerDefaultShippingAddressInput(
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
