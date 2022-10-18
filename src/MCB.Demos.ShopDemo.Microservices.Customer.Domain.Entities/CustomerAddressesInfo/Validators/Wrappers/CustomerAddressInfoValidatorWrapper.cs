using FluentValidation;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Specifications.Interfaces;
using System.Linq.Expressions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators.Wrappers;

public static class CustomerAddressInfoValidatorWrapper
{
    public static void AddCustomerAddressInfoShouldHaveCustomerAddressCollection<TInput, TProperty>(
        ICustomerAddressInfoSpecifications customerAddressInfoSpecifications,
        ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
        Expression<Func<TInput, TProperty>> propertyExpression,
        Func<TInput, IEnumerable<CustomerAddress>> getCustomerAddressCollectionFunction
    )
    {
        fluentValidationValidatorWrapper.RuleFor(propertyExpression)
            .Must((input, customerAddressCollection) => customerAddressInfoSpecifications.CustomerAddressInfoShouldHaveCustomerAddressCollection(getCustomerAddressCollectionFunction(input)))
            .WithErrorCode(ICustomerAddressInfoSpecifications.CustomerAddressInfoShouldHaveCustomerAddressCollectionErrorCode)
            .WithMessage(ICustomerAddressInfoSpecifications.CustomerAddressInfoShouldHaveCustomerAddressCollectionMessage)
            .WithSeverity(ICustomerAddressInfoSpecifications.CustomerAddressInfoShouldHaveCustomerAddressCollectionSeverity);
    }
    public static void AddCustomerAddressInfoShouldHaveDefaultShippingAddress<TInput, TProperty>(
        ICustomerAddressInfoSpecifications customerAddressInfoSpecifications,
        ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
        Expression<Func<TInput, TProperty>> propertyExpression,
        Func<TInput, CustomerAddress> getDefaultShippingAddressFunction
    )
    {
        fluentValidationValidatorWrapper.RuleFor(propertyExpression)
            .Must((input, defaultShippingAddress) => customerAddressInfoSpecifications.CustomerAddressInfoShouldHaveDefaultShippingAddress(getDefaultShippingAddressFunction(input)))
            .WithErrorCode(ICustomerAddressInfoSpecifications.CustomerAddressInfoShouldHaveDefaultShippingAddressErrorCode)
            .WithMessage(ICustomerAddressInfoSpecifications.CustomerAddressInfoShouldHaveDefaultShippingAddressMessage)
            .WithSeverity(ICustomerAddressInfoSpecifications.CustomerAddressInfoShouldHaveDefaultShippingAddressSeverity);
    }
    public static void AddCustomerAddressInfoShouldHaveDefaultShippingAddressInCustomerAddressCollection<TInput, TProperty>(
        ICustomerAddressInfoSpecifications customerAddressInfoSpecifications,
        ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
        Expression<Func<TInput, TProperty>> propertyExpression,
        Func<TInput, (CustomerAddress defaultShippingAddress, IEnumerable<CustomerAddress> customerAddressCollection)> getFunction
    )
    {
        fluentValidationValidatorWrapper.RuleFor(propertyExpression)
            .Must((input, property) => customerAddressInfoSpecifications.CustomerAddressInfoShouldHaveDefaultShippingAddressInCustomerAddressCollection(getFunction(input).defaultShippingAddress, getFunction(input).customerAddressCollection))
            .WithErrorCode(ICustomerAddressInfoSpecifications.CustomerAddressInfoShouldHaveDefaultShippingAddressInCustomerAddressCollectionErrorCode)
            .WithMessage(ICustomerAddressInfoSpecifications.CustomerAddressInfoShouldHaveDefaultShippingAddressInCustomerAddressCollectionMessage)
            .WithSeverity(ICustomerAddressInfoSpecifications.CustomerAddressInfoShouldHaveDefaultShippingAddressInCustomerAddressCollectionSeverity);
    }
    public static void AddCustomerAddressInfoShouldHaveCustomerAddressInCustomerAddressCollection<TInput, TProperty>(
        ICustomerAddressInfoSpecifications customerAddressInfoSpecifications,
        ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
        Expression<Func<TInput, TProperty>> propertyExpression,
        Func<TInput, (Guid customerAddressId, IEnumerable<CustomerAddress> customerAddressCollection)> getFunction
    )
    {
        fluentValidationValidatorWrapper.RuleFor(propertyExpression)
            .Must((input, property) => customerAddressInfoSpecifications.CustomerAddressInfoShouldHaveCustomerAddressInCustomerAddressCollection(getFunction(input).customerAddressId, getFunction(input).customerAddressCollection))
            .WithErrorCode(ICustomerAddressInfoSpecifications.CustomerAddressInfoShouldHaveCustomerAddressInCustomerAddressCollectionErrorCode)
            .WithMessage(ICustomerAddressInfoSpecifications.CustomerAddressInfoShouldHaveCustomerAddressInCustomerAddressCollectionMessage)
            .WithSeverity(ICustomerAddressInfoSpecifications.CustomerAddressInfoShouldHaveCustomerAddressInCustomerAddressCollectionSeverity);
    }
}