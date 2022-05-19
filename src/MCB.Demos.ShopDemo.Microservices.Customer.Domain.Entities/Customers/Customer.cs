﻿using MCB.Core.Domain.Entities;
using MCB.Core.Domain.Entities.Abstractions;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers
{
    public class Customer
        : DomainEntityBase,
        IAggregationRoot
    {
        // Fields
        private static CustomerRegisterNewInputValidator _customerRegisterNewInputValidator = new();
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
        public Customer RegisterNew(RegisterNewCustomerInput input)
        {
            // Validate
            var validationResult = _customerRegisterNewInputValidator.Validate(input);

            // Process and Return
            return SetName(input.FirstName, input.LastName)
                .SetBirthDate(input.BirthDate)
                .RegisterNewInternal<Customer>(input.TenantId, input.ExecutionUser, input.SourcePlatform);
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
        public CustomerAddress RemoveCustomerAddress(Guid customerAddressId, string executionUser, string sourcePlatform)
        {
            // Validate
            // TODO: Add validation

            // Process
            var removedCustomerAddress = _customerAddressInfo.RemoveCustomerAddress(customerAddressId, executionUser, sourcePlatform);
            RegisterModificationInternal<Customer>(executionUser, sourcePlatform);

            // Return
            return removedCustomerAddress;
        }
        public CustomerAddress ChangeCustomerAddress(Guid customerAddressId, CustomerAddressType customerAddressType, AddressValueObject addressValueObject, string executionUser, string sourcePlatform)
        {
            var customerAddress = _customerAddressInfo.CustomerAddressCollection.FirstOrDefault(q => q.Id == customerAddressId);

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