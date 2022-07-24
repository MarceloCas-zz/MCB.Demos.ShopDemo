using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs
{
    public record AddNewCustomerAddressInput
        : InputBase
    {
        public CustomerAddressType CustomerAddressType { get; }
        public AddressValueObject AddressValueObject { get; }

        public AddNewCustomerAddressInput(
            Guid tenantId,
            CustomerAddressType customerAddressType, 
            AddressValueObject addressValueObject,
            string executionUser,
            string sourcePlatform
        ) : base(tenantId, executionUser, sourcePlatform)
        {
            CustomerAddressType = customerAddressType;
            AddressValueObject = addressValueObject;
        }
    }
}
