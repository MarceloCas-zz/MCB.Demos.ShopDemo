﻿using MCB.Core.Domain.Entities.DomainEntitiesBase.Validators;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Wrappers;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators
{
    public class ChangeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator
        : InputBaseValidator<ChangeDefaultCustomerAddressInfoShippingAddressInput>,
        IChangeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator
    {
        // Fields
        private readonly ICustomerAddressSpecifications _customerAddressSpecifications;

        // Constructors
        public ChangeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator(
            ICustomerAddressSpecifications customerAddressSpecifications
        )
        {
            _customerAddressSpecifications = customerAddressSpecifications;
        }

        protected override void ConfigureFluentValidationConcreteValidatorInternal(ValidatorBase<ChangeDefaultCustomerAddressInfoShippingAddressInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
        {
            CustomerAddressValidatorWrapper.AddCustomerAddressShouldHaveId(
                _customerAddressSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: q => q.CustomerAddressId,
                getIdFunction: q => q.CustomerAddressId
            );
        }
    }
}
