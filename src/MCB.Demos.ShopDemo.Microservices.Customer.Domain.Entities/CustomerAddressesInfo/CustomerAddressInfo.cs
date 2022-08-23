﻿using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo
{
    public class CustomerAddressInfo
        : DomainEntityBase
    {
        // Fields
        private readonly List<CustomerAddress> _customerAddressCollection = new();
        private CustomerAddress _defaultShippingAddress;

        // Validators

        // Properties
        public IEnumerable<CustomerAddress> CustomerAddressCollection => _customerAddressCollection.Select(q => q.DeepClone());
        public CustomerAddress DefaultShippingAddress => _defaultShippingAddress?.DeepClone();

        // Constructors
        public CustomerAddressInfo()
        {

        }

        // Public Methods
        public CustomerAddressInfo RegisterNewCustomerAddressInfo(RegisterNewCustomerAddressInfoInput input)
        {
            // Validate
            // TODO: Add validation

            // Process and Return
            return RegisterNewInternal<CustomerAddressInfo>(input.TenantId, input.ExecutionUser, input.SourcePlatform);
        }
        public CustomerAddress ChangeDefaultCustomerAddressInfoShippingAddress(ChangeDefaultCustomerAddressInfoShippingAddressInput input)
        {
            // Validate
            // TODO: Add validation

            // Process and Return
            SetDefaultShippingAddress(input.CustomerAddress)
                .RegisterModificationInternal<CustomerAddressInfo>(input.ExecutionUser, input.SourcePlatform);

            return input.CustomerAddress;
        }
        public CustomerAddressInfo ClearDefaultCustomerAddressInfoShippingAddress(ClearDefaultCustomerAddressInfoShippingAddressInput input)
        {
            // Validate
            // TODO: Add validation

            // Process and Return
            return SetDefaultShippingAddress(null)
                .RegisterModificationInternal<CustomerAddressInfo>(input.ExecutionUser, input.SourcePlatform);
        }

        public CustomerAddress AddNewCustomerAddressInfoCustomerAddress(AddNewCustomerAddressInfoCustomerAddressInput input)
        {
            // Validate
            //if (!Validate(() => _addNewCustomerAddressInputShouldBeValidValidator.Validate(input)))
            //    return null;

            // Process
            var customerAddress = new CustomerAddress(
                    new ChangeCustomerAddressTypeValidator(new CustomerAddressSpecifications()),
                    new ChangeCustomerAddressValidator(new CustomerAddressSpecifications()),
                    new ChangeCustomerFullAddressInfoValidator(new CustomerAddressSpecifications()),
                    new RegisterNewCustomerAddressValidator(new CustomerAddressSpecifications())
                )
                .RegisterNewCustomerAddress(new CustomerAddresses.Inputs.RegisterNewCustomerAddressInput(
                    input.TenantId, 
                    input.CustomerAddressType, 
                    input.AddressValueObject, 
                    input.ExecutionUser, 
                    input.SourcePlatform
                ));
            _customerAddressCollection.Add(
                customerAddress
            );
            RegisterModificationInternal<CustomerAddressInfo>(input.ExecutionUser, input.SourcePlatform);

            // Return
            return customerAddress;
        }
        public CustomerAddress RemoveCustomerAddressInfoCustomerAddress(RemoveCustomerAddressInfoCustomerAddressInput input)
        {
            // Validate
            // TODO: Add validation

            // Process
            var customerAddress = _customerAddressCollection.FirstOrDefault(q => q.Id == input.CustomerAddressId);
            if (customerAddress is null)
                return null;

            _customerAddressCollection.Remove(
                customerAddress
            );
            RegisterModificationInternal<CustomerAddressInfo>(input.ExecutionUser, input.SourcePlatform);

            // Return
            return customerAddress;
        }
        public CustomerAddress ChangeCustomerAddressInfoCustomerAddress(ChangeCustomerAddressInfoCustomerAddressInput input)
        {
            var customerAddress = _customerAddressCollection.FirstOrDefault(q => q.Id == input.CustomerAddressId);

            // Validate
            // TODO: Add validation
            if (customerAddress == null)
                return null;

            // Process
            customerAddress.ChangeCustomerFullAddressInfo(new CustomerAddresses.Inputs.ChangeCustomerFullAddressInfoInput(
                input.TenantId,
                input.CustomerAddressType, 
                input.AddressValueObject, 
                input.ExecutionUser,
                input.SourcePlatform
            ));
            RegisterModificationInternal<CustomerAddressInfo>(input.ExecutionUser, input.SourcePlatform);

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
