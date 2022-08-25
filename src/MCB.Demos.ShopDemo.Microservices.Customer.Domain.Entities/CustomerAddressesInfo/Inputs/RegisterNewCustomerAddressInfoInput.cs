using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.AddressValueObjects;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs
{
    public record RegisterNewCustomerAddressInfoInput
        : InputBase
    {
        // Properties
        public CustomerAddressType CustomerAddressType { get; }
        public AddressValueObject AddressValueObject { get; }
        public bool IsDefaultShippingAddress { get; }

        // Constructors
        public RegisterNewCustomerAddressInfoInput(
            Guid tenantId,
            string executionUser,
            string sourcePlatform,
            CustomerAddressType customerAddressType,
            AddressValueObject addressValueObject,
            bool isDefaultShippingAddress
        ) : base(tenantId, executionUser, sourcePlatform)
        {
            CustomerAddressType = customerAddressType;
            AddressValueObject = addressValueObject;
            IsDefaultShippingAddress = isDefaultShippingAddress;
        }
    }
}
