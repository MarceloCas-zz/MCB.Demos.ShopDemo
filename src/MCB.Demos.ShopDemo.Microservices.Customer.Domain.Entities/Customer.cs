﻿using MCB.Core.Domain.Entities;
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
        private readonly CustomerAddressInfo _customerAddressInfo = new();

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

        public Customer ChangeDefaultShippingAddress(CustomerAddress customerAddress, string executionUser, string sourcePlatform)
        {
            // Validate
            // TODO: Add validation

            // Process
            _customerAddressInfo.ChangeDefaultShippingAddress(customerAddress, executionUser, sourcePlatform);
            RegisterModificationInternal<Customer>(executionUser, sourcePlatform);

            // Return
            return this;
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

        public Customer AddNewCustomerAddress(CustomerAddressType customerAddressType, AddressValueObject addressValueObject, string executionUser, string sourcePlatform)
        {
            // Validate
            // TODO: Add validation

            // Process
            _customerAddressInfo.AddNewCustomerAddress(customerAddressType, addressValueObject, executionUser, sourcePlatform);
            RegisterModificationInternal<Customer>(executionUser, sourcePlatform);

            // Return
            return this;
        }
        public Customer RemoveCustomerAddress(Guid customerAddressId, string executionUser, string sourcePlatform)
        {
            // Validate
            // TODO: Add validation

            // Process
            _customerAddressInfo.RemoveCustomerAddress(customerAddressId, executionUser, sourcePlatform);
            RegisterModificationInternal<Customer>(executionUser, sourcePlatform);

            // Return
            return this;
        }
        public Customer ChangeCustomerAddress(Guid customerAddressId, CustomerAddressType customerAddressType, AddressValueObject addressValueObject, string executionUser, string sourcePlatform)
        {
            var customerAddress = _customerAddressInfo.CustomerAddressCollection.First(q => q.Id == customerAddressId);

            // Validate
            // TODO: Add validation
            if (customerAddress == null)
                throw new InvalidOperationException();

            // Process
            _customerAddressInfo.ChangeCustomerAddress(customerAddressId, customerAddressType, addressValueObject, executionUser, sourcePlatform);
            RegisterModificationInternal<Customer>(executionUser, sourcePlatform);

            // Return
            return this;
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
    }
}
