﻿using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.AddressValueObjects;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses;

public class CustomerAddress
    : DomainEntityBase
{
    // Properties
    public CustomerAddressType CustomerAddressType { get; private set; }
    public AddressValueObject AddressValueObject { get; private set; }

    // Public Methods
    public CustomerAddress RegisterNewCustomerAddress(RegisterNewCustomerAddressInput input)
    {
        // Validate
        // TODO: Add validation

        // Process
        return RegisterNewInternal<CustomerAddress>(input.TenantId, input.ExecutionUser, input.SourcePlatform)
            .SetCustomerAddressType(input.CustomerAddressType)
            .SetAddress(input.AddressValueObject);
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
