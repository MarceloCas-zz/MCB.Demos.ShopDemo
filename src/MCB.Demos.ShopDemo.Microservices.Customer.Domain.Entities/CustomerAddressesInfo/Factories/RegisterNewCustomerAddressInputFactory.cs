﻿using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories
{
    public class RegisterNewCustomerAddressInputFactory
        : IRegisterNewCustomerAddressInputFactory
    {
        public RegisterNewCustomerAddressInput Create(RegisterNewCustomerAddressInfoInput parameter)
        {
            return new RegisterNewCustomerAddressInput(
                parameter.TenantId,
                parameter.CustomerAddressType,
                parameter.AddressValueObject,
                parameter.ExecutionUser,
                parameter.SourcePlatform
            );
        }
    }
}