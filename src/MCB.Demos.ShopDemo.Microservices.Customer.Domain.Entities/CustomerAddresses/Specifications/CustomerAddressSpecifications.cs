﻿using MCB.Core.Domain.Entities.DomainEntitiesBase.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.AddressValueObjects;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications
{
    public class CustomerAddressSpecifications
        : DomainEntitySpecifications,
        ICustomerAddressSpecifications
    {
        // Public Methods
        public bool CustomerAddressShouldHaveCustomerAddressType(CustomerAddressType customerAddressType)
        {
            return Enum.IsDefined(typeof(CustomerAddressType), customerAddressType);
        }
        public bool CustomerAddressShouldHaveAddressValueObject(AddressValueObject addressValueObject)
        {
            return !addressValueObject.Equals(new AddressValueObject());
        }
    }
}