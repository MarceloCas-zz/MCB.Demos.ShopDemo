using MCB.Core.Domain.Entities;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities
{
    public class CustomerAddress
        : DomainEntityBase
    {
        // Properties
        public CustomerAddressType CustomerAddressType { get; private set; }
        public AddressValueObject AddressValueObject { get; private set; }

        // Public Methods
        public CustomerAddress RegisterNew(Guid tenantId, CustomerAddressType customerAddressType, AddressValueObject addressValueObject, string executionUser, string sourcePlatform)
        {
            // Validate
            // TODO: Add validation

            // Process
            return RegisterNewInternal<CustomerAddress>(tenantId, executionUser, sourcePlatform)
                .SetCustomerAddressType(customerAddressType)
                .SetAddress(addressValueObject);
        }
        public CustomerAddress ChangeCustomerAddressType(CustomerAddressType customerAddressType, string executionUser, string sourcePlatform)
        {
            // Validate
            // TODO: Add validation

            // Process
            return SetCustomerAddressType(customerAddressType)
                .RegisterModificationInternal<CustomerAddress>(executionUser, sourcePlatform);
        }
        public CustomerAddress ChangeAddress(AddressValueObject addressValueObject, string executionUser, string sourcePlatform)
        {
            // Validate
            // TODO: Add validation

            // Process and return
            return SetAddress(addressValueObject)
                .RegisterModificationInternal<CustomerAddress>(executionUser, sourcePlatform);
        }
        public CustomerAddress ChangeFullAddressInfo(CustomerAddressType customerAddressType, AddressValueObject addressValueObject, string executionUser, string sourcePlatform)
        {
            // Validate
            // TODO: Add validation

            // Process
            return SetCustomerAddressType(customerAddressType)
                .SetAddress(addressValueObject)
                .RegisterModificationInternal<CustomerAddress>(executionUser, sourcePlatform);
        }

        public CustomerAddress DeepClone()
        {
            // Process and Return
            return DeepCloneInternal<CustomerAddress>()
                .SetCustomerAddressType(CustomerAddressType)
                .SetAddress(AddressValueObject);
        }

        // Protected Abstract Methods
        protected override DomainEntityBase CreateInstanceForCloneInternal() => new CustomerAddress();

        // Private Methods
        private CustomerAddress SetCustomerAddressType(CustomerAddressType customerAddressType)
        {
            CustomerAddressType = customerAddressType;
            return this;
        }
        private CustomerAddress SetAddress(AddressValueObject addressValueObject)
        {
            AddressValueObject = addressValueObject;
            return this;
        }
    }
}
