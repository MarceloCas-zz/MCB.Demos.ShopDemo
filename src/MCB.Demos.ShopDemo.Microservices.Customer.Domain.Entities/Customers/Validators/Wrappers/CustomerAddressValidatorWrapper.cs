﻿using FluentValidation;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.AddressValueObjects;
using System.Linq.Expressions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Wrappers
{
    public static class CustomerAddressValidatorWrapper
    {
        public static void AddCustomerAddressShouldHaveCustomerAddressType<TInput, TProperty>(
            ICustomerAddressSpecifications customerAddressSpecifications,
            ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
            Expression<Func<TInput, TProperty>> propertyExpression,
            Func<TInput, CustomerAddressType> getCustomerAddressTypeFunction
        )
        {
            fluentValidationValidatorWrapper.RuleFor(propertyExpression)
                .Must((input, customerAddressType) => customerAddressSpecifications.CustomerAddressShouldHaveCustomerAddressType(getCustomerAddressTypeFunction(input)))
                .WithErrorCode(ICustomerAddressSpecifications.CustomerAddressShouldHaveCustomerAddressTypeErrorCode)
                .WithMessage(ICustomerAddressSpecifications.CustomerAddressShouldHaveCustomerAddressTypeMessage)
                .WithSeverity(ICustomerAddressSpecifications.CustomerAddressShouldHaveCustomerAddressTypeSeverity);
        }
        public static void AddCustomerAddressShouldHaveAddressValueObject<TInput, TProperty>(
            ICustomerAddressSpecifications customerAddressSpecifications,
            ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
            Expression<Func<TInput, TProperty>> propertyExpression,
            Func<TInput, AddressValueObject> getAddressValueObjectFunction
        )
        {
            fluentValidationValidatorWrapper.RuleFor(propertyExpression)
                .Must((input, customerAddressType) => customerAddressSpecifications.CustomerAddressShouldHaveAddressValueObject(getAddressValueObjectFunction(input)))
                .WithErrorCode(ICustomerAddressSpecifications.CustomerAddressShouldHaveCustomerAddressTypeErrorCode)
                .WithMessage(ICustomerAddressSpecifications.CustomerAddressShouldHaveCustomerAddressTypeMessage)
                .WithSeverity(ICustomerAddressSpecifications.CustomerAddressShouldHaveCustomerAddressTypeSeverity);
        }
    }
}