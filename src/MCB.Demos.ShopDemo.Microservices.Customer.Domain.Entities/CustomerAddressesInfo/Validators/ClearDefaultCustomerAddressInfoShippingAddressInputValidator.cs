﻿using MCB.Core.Domain.Entities.DomainEntitiesBase.Validators;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators
{
    public class ClearDefaultCustomerAddressInfoShippingAddressInputValidator
        : InputBaseValidator<ClearDefaultCustomerAddressInfoShippingAddressInput>,
        IClearDefaultCustomerAddressInfoShippingAddressInputValidator
    {
        // Protected Methods
        protected override void ConfigureFluentValidationConcreteValidatorInternal(ValidatorBase<ClearDefaultCustomerAddressInfoShippingAddressInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
        {

        }
    }
}
