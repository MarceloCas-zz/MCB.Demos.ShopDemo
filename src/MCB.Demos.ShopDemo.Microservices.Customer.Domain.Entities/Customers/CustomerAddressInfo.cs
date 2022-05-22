using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers
{
    public class CustomerAddressInfo
        : DomainEntityBase
    {
        // Fields
        private readonly List<CustomerAddress> _customerAddressCollection = new();
        private CustomerAddress _defaultShippingAddress;

        // Properties
        public IEnumerable<CustomerAddress> CustomerAddressCollection => _customerAddressCollection.Select(q => q.DeepClone());
        public CustomerAddress DefaultShippingAddress => _defaultShippingAddress?.DeepClone();

        // Public Methods
        public CustomerAddressInfo RegisterNew(Guid tenantId, string executionUser, string sourcePlatform)
        {
            // Validate
            // TODO: Add validation

            // Process and Return
            return RegisterNewInternal<CustomerAddressInfo>(tenantId, executionUser, sourcePlatform);
        }
        public CustomerAddress ChangeDefaultShippingAddress(CustomerAddress customerAddress, string executionUser, string sourcePlatform)
        {
            // Validate
            // TODO: Add validation

            // Process and Return
            SetDefaultShippingAddress(customerAddress)
                .RegisterModificationInternal<CustomerAddressInfo>(executionUser, sourcePlatform);

            return customerAddress;
        }
        public CustomerAddressInfo ClearDefaultShippingAddress(string executionUser, string sourcePlatform)
        {
            // Validate
            // TODO: Add validation

            // Process and Return
            return SetDefaultShippingAddress(null)
                .RegisterModificationInternal<CustomerAddressInfo>(executionUser, sourcePlatform);
        }

        public CustomerAddress AddNewCustomerAddress(CustomerAddressType customerAddressType, AddressValueObject addressValueObject, string executionUser, string sourcePlatform)
        {
            // Validate
            // TODO: Add validation

            // Process
            var customerAddress = new CustomerAddress().RegisterNew(TenantId, customerAddressType, addressValueObject, executionUser, sourcePlatform);
            _customerAddressCollection.Add(
                customerAddress
            );
            RegisterModificationInternal<CustomerAddressInfo>(executionUser, sourcePlatform);

            // Return
            return customerAddress;
        }
        public CustomerAddress RemoveCustomerAddress(Guid customerAddressId, string executionUser, string sourcePlatform)
        {
            // Validate
            // TODO: Add validation

            // Process
            var customerAddress = _customerAddressCollection.FirstOrDefault(q => q.Id == customerAddressId);
            if (customerAddress is null)
                return null;

            _customerAddressCollection.Remove(
                customerAddress
            );
            RegisterModificationInternal<CustomerAddressInfo>(executionUser, sourcePlatform);

            // Return
            return customerAddress;
        }
        public CustomerAddress ChangeCustomerAddress(Guid customerAddressId, CustomerAddressType customerAddressType, AddressValueObject addressValueObject, string executionUser, string sourcePlatform)
        {
            var customerAddress = _customerAddressCollection.FirstOrDefault(q => q.Id == customerAddressId);

            // Validate
            // TODO: Add validation
            if (customerAddress == null)
                return null;

            // Process
            customerAddress.ChangeFullAddressInfo(customerAddressType, addressValueObject, executionUser, sourcePlatform);
            RegisterModificationInternal<CustomerAddressInfo>(executionUser, sourcePlatform);

            // Return
            return customerAddress;
        }

        public CustomerAddressInfo DeepClone()
        {
            // Process
            var customerAddressInfo = DeepCloneInternal<CustomerAddressInfo>()
                .SetcustomerAddressCollection(_customerAddressCollection);

            if (_defaultShippingAddress != null)
                customerAddressInfo.SetDefaultShippingAddress(_defaultShippingAddress);

            // Return
            return customerAddressInfo;
        }

        // Private Methods
        private CustomerAddressInfo SetcustomerAddressCollection(IEnumerable<CustomerAddress> customerAddressCollection)
        {
            // Validate
            // TODO: Add validation

            // Process
            _customerAddressCollection.Clear();
            _customerAddressCollection.AddRange(customerAddressCollection);

            // Return
            return this;
        }
        private CustomerAddressInfo SetDefaultShippingAddress(CustomerAddress customerAddress)
        {
            _defaultShippingAddress = customerAddress;
            return this;
        }

        // Protected Abstract Methods
        protected override DomainEntityBase CreateInstanceForCloneInternal() => new CustomerAddressInfo();
    }
}
