using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.AddressValueObjects;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs
{
    public record AddNewCustomerAddressInfoCustomerAddressInput
        : InputBase
    {
        // Public Methods
        public CustomerAddressType CustomerAddressType { get; } 
        public AddressValueObject AddressValueObject { get; }

        // Public Methods
        public AddNewCustomerAddressInfoCustomerAddressInput(
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
