using MCB.Core.Domain.Entities;
using MCB.Core.Domain.Entities.Abstractions;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities
{
    public class Customer
        : DomainEntityBase,
        IAggregationRoot
    {
        // Fields
        private CustomerAddressInfo _customerAddressInfo = new();

        // Properties
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateOnly BirthDate { get; private set; }

        // Navigation Properties
        public CustomerAddressInfo CustomerAddressInfo => _customerAddressInfo.DeepClone();

        // Constructors
        public Customer()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
        }

        // Public Methods
        public Customer RegisterNew(
            Guid tenantId,
            string firstName,
            string lastName,
            DateOnly birthDate,
            string executionUser,
            string sourcePlatform
        )
        {
            // Validate
            // TODO: Add validation

            // Process and Return
            return SetName(firstName, lastName)
                .SetBirthDate(birthDate)
                .RegisterNewInternal<Customer>(tenantId, executionUser, sourcePlatform);
        }
        public Customer ChangeName(
            string firstName, 
            string lastName,
            string executionUser,
            string sourcePlatform
        )
        {
            // Validate
            // TODO: Add validation

            // Process and Return
            return SetName(firstName, lastName)
                .RegisterModificationInternal<Customer>(executionUser, sourcePlatform);
        }
        public Customer ChangeBirthDate(
            DateOnly birthDate,
            string executionUser,
            string sourcePlatform
        )
        {
            // Validate
            // TODO: Add validation

            // Process and Return
            return SetBirthDate(birthDate)
                .RegisterModificationInternal<Customer>(executionUser, sourcePlatform);
        }

        public CustomerAddress ChangeDefaultShippingAddress(CustomerAddress customerAddress, string executionUser, string sourcePlatform)
        {
            // Validate
            // TODO: Add validation

            // Process
            var newDefaultShippingAddress = _customerAddressInfo.ChangeDefaultShippingAddress(customerAddress, executionUser, sourcePlatform);
            RegisterModificationInternal<Customer>(executionUser, sourcePlatform);

            // Return
            return newDefaultShippingAddress;
        }
        public Customer ClearDefaultShippingAddress(string executionUser, string sourcePlatform)
        {
            // Validate
            // TODO: Add validation

            // Process
            _customerAddressInfo.ClearDefaultShippingAddress(executionUser, sourcePlatform);
            RegisterModificationInternal<Customer>(executionUser, sourcePlatform);

            // Return
            return this;
        }

        public CustomerAddress AddNewCustomerAddress(CustomerAddressType customerAddressType, AddressValueObject addressValueObject, string executionUser, string sourcePlatform)
        {
            // Validate
            // TODO: Add validation

            // Process
            var addedCustomerAddress = _customerAddressInfo.AddNewCustomerAddress(customerAddressType, addressValueObject, executionUser, sourcePlatform);
            RegisterModificationInternal<Customer>(executionUser, sourcePlatform);

            // Return
            return addedCustomerAddress;
        }
        public CustomerAddress? RemoveCustomerAddress(Guid customerAddressId, string executionUser, string sourcePlatform)
        {
            // Validate
            // TODO: Add validation

            // Process
            var removedCustomerAddress = _customerAddressInfo.RemoveCustomerAddress(customerAddressId, executionUser, sourcePlatform);
            RegisterModificationInternal<Customer>(executionUser, sourcePlatform);

            // Return
            return removedCustomerAddress;
        }
        public CustomerAddress? ChangeCustomerAddress(Guid customerAddressId, CustomerAddressType customerAddressType, AddressValueObject addressValueObject, string executionUser, string sourcePlatform)
        {
            var customerAddress = _customerAddressInfo.CustomerAddressCollection.First(q => q.Id == customerAddressId);

            // Validate
            // TODO: Add validation
            if (customerAddress == null)
                return null;

            // Process
            var changedCustomerAddress = _customerAddressInfo.ChangeCustomerAddress(customerAddressId, customerAddressType, addressValueObject, executionUser, sourcePlatform);
            RegisterModificationInternal<Customer>(executionUser, sourcePlatform);

            // Return
            return changedCustomerAddress;
        }

        public Customer DeepClone()
        {
            // Process and Return
            return DeepCloneInternal<Customer>()
                .SetName(FirstName, LastName)
                .SetBirthDate(BirthDate)
                .SetCustomerAddressInfo(CustomerAddressInfo);
        }

        // Protected Abstract Methods
        protected override DomainEntityBase CreateInstanceForCloneInternal() => new Customer();

        // Private Methods
        private Customer SetName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            return this;
        }
        private Customer SetBirthDate(DateOnly birthDate)
        {
            BirthDate = birthDate;

            return this;
        }
        private Customer SetCustomerAddressInfo(CustomerAddressInfo customerAddressInfo)
        {
            _customerAddressInfo = customerAddressInfo;
            return this;
        }
    }
}
