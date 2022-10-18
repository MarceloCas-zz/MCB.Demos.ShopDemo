using FluentValidation;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address.Specifications.Interfaces;
using System.Linq.Expressions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address.Validators.Wrappers;

public static class AddressValueObjectValidatorWrapper
{
    // Street
    public static void AddAddressValueObjectShouldHaveStreet<TInput, TProperty>(
        IAddressValueObjectSpecifications addressValueObjectSpecifications,
        ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
        Expression<Func<TInput, TProperty>> propertyExpression,
        Func<TInput, string> getStreetFunction
    )
    {
        fluentValidationValidatorWrapper.RuleFor(propertyExpression)
            .Must((addressValueObject, street) => addressValueObjectSpecifications.AddressValueObjectShouldHaveStreet(getStreetFunction(addressValueObject)))
            .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStreetErrorCode)
            .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStreetMessage)
            .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStreetSeverity);
    }
    public static void AddAddressValueObjectShouldHaveStreetMaximumLength<TInput, TProperty>(
        IAddressValueObjectSpecifications addressValueObjectSpecifications,
        ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
        Expression<Func<TInput, TProperty>> propertyExpression,
        Func<TInput, string> getStreetFunction
    )
    {
        fluentValidationValidatorWrapper.RuleFor(q => propertyExpression)
            .Must((input, street) => addressValueObjectSpecifications.AddressValueObjectShouldHaveStreetMaximumLength(getStreetFunction(input)))
            .When(input => addressValueObjectSpecifications.AddressValueObjectShouldHaveStreet(getStreetFunction(input)))
            .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStreetMaximumLengthErrorCode)
            .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStreetMaximumLengthMessage)
            .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStreetMaximumLengthSeverity);

    }

    // Number
    public static void AddAddressValueObjectShouldHaveNumber<TInput, TProperty>(
        IAddressValueObjectSpecifications addressValueObjectSpecifications,
        ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
        Expression<Func<TInput, TProperty>> propertyExpression,
        Func<TInput, string> getNumberFunction
    )
    {
        fluentValidationValidatorWrapper.RuleFor(propertyExpression)
            .Must((addressValueObject, number) => addressValueObjectSpecifications.AddressValueObjectShouldHaveNumber(getNumberFunction(addressValueObject)))
            .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveNumberErrorCode)
            .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveNumberMessage)
            .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveNumberSeverity);
    }
    public static void AddAddressValueObjectShouldHaveNumberMaximumLength<TInput, TProperty>(
        IAddressValueObjectSpecifications addressValueObjectSpecifications,
        ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
        Expression<Func<TInput, TProperty>> propertyExpression,
        Func<TInput, string> getNumberFunction
    )
    {
        fluentValidationValidatorWrapper.RuleFor(q => propertyExpression)
            .Must((input, number) => addressValueObjectSpecifications.AddressValueObjectShouldHaveNumberMaximumLength(getNumberFunction(input)))
            .When(input => addressValueObjectSpecifications.AddressValueObjectShouldHaveNumber(getNumberFunction(input)))
            .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveNumberMaximumLengthErrorCode)
            .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveNumberMaximumLengthMessage)
            .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveNumberMaximumLengthSeverity);

    }

    // City
    public static void AddAddressValueObjectShouldHaveCity<TInput, TProperty>(
        IAddressValueObjectSpecifications addressValueObjectSpecifications,
        ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
        Expression<Func<TInput, TProperty>> propertyExpression,
        Func<TInput, string> getCityFunction
    )
    {
        fluentValidationValidatorWrapper.RuleFor(propertyExpression)
            .Must((addressValueObject, city) => addressValueObjectSpecifications.AddressValueObjectShouldHaveCity(getCityFunction(addressValueObject)))
            .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCityErrorCode)
            .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCityMessage)
            .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCitySeverity);
    }
    public static void AddAddressValueObjectShouldHaveCityMaximumLength<TInput, TProperty>(
        IAddressValueObjectSpecifications addressValueObjectSpecifications,
        ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
        Expression<Func<TInput, TProperty>> propertyExpression,
        Func<TInput, string> getCityFunction
    )
    {
        fluentValidationValidatorWrapper.RuleFor(q => propertyExpression)
            .Must((input, city) => addressValueObjectSpecifications.AddressValueObjectShouldHaveCityMaximumLength(getCityFunction(input)))
            .When(input => addressValueObjectSpecifications.AddressValueObjectShouldHaveCity(getCityFunction(input)))
            .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCityMaximumLengthErrorCode)
            .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCityMaximumLengthMessage)
            .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCityMaximumLengthSeverity);

    }

    // State
    public static void AddAddressValueObjectShouldHaveState<TInput, TProperty>(
        IAddressValueObjectSpecifications addressValueObjectSpecifications,
        ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
        Expression<Func<TInput, TProperty>> propertyExpression,
        Func<TInput, string> getStateFunction
    )
    {
        fluentValidationValidatorWrapper.RuleFor(propertyExpression)
            .Must((addressValueObject, state) => addressValueObjectSpecifications.AddressValueObjectShouldHaveState(getStateFunction(addressValueObject)))
            .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStateErrorCode)
            .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStateMessage)
            .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStateSeverity);
    }
    public static void AddAddressValueObjectShouldHaveStateMaximumLength<TInput, TProperty>(
        IAddressValueObjectSpecifications addressValueObjectSpecifications,
        ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
        Expression<Func<TInput, TProperty>> propertyExpression,
        Func<TInput, string> getStateFunction
    )
    {
        fluentValidationValidatorWrapper.RuleFor(q => propertyExpression)
            .Must((input, state) => addressValueObjectSpecifications.AddressValueObjectShouldHaveStateMaximumLength(getStateFunction(input)))
            .When(input => addressValueObjectSpecifications.AddressValueObjectShouldHaveState(getStateFunction(input)))
            .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStateMaximumLengthErrorCode)
            .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStateMaximumLengthMessage)
            .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStateMaximumLengthSeverity);

    }

    // Country
    public static void AddAddressValueObjectShouldHaveCountry<TInput, TProperty>(
        IAddressValueObjectSpecifications addressValueObjectSpecifications,
        ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
        Expression<Func<TInput, TProperty>> propertyExpression,
        Func<TInput, string> getCountryFunction
    )
    {
        fluentValidationValidatorWrapper.RuleFor(propertyExpression)
            .Must((addressValueObject, country) => addressValueObjectSpecifications.AddressValueObjectShouldHaveCountry(getCountryFunction(addressValueObject)))
            .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCountryErrorCode)
            .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCountryMessage)
            .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCountrySeverity);
    }
    public static void AddAddressValueObjectShouldHaveCountryMaximumLength<TInput, TProperty>(
        IAddressValueObjectSpecifications addressValueObjectSpecifications,
        ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
        Expression<Func<TInput, TProperty>> propertyExpression,
        Func<TInput, string> getCountryFunction
    )
    {
        fluentValidationValidatorWrapper.RuleFor(q => propertyExpression)
            .Must((input, country) => addressValueObjectSpecifications.AddressValueObjectShouldHaveCountryMaximumLength(getCountryFunction(input)))
            .When(input => addressValueObjectSpecifications.AddressValueObjectShouldHaveCountry(getCountryFunction(input)))
            .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCountryMaximumLengthErrorCode)
            .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCountryMaximumLengthMessage)
            .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCountryMaximumLengthSeverity);

    }

    // ZipCode
    public static void AddAddressValueObjectShouldHaveZipCode<TInput, TProperty>(
        IAddressValueObjectSpecifications addressValueObjectSpecifications,
        ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
        Expression<Func<TInput, TProperty>> propertyExpression,
        Func<TInput, string> getZipCodeFunction
    )
    {
        fluentValidationValidatorWrapper.RuleFor(propertyExpression)
            .Must((addressValueObject, zipCode) => addressValueObjectSpecifications.AddressValueObjectShouldHaveZipCode(getZipCodeFunction(addressValueObject)))
            .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveZipCodeErrorCode)
            .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveZipCodeMessage)
            .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveZipCodeSeverity);
    }
    public static void AddAddressValueObjectShouldHaveZipCodeMaximumLength<TInput, TProperty>(
        IAddressValueObjectSpecifications addressValueObjectSpecifications,
        ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
        Expression<Func<TInput, TProperty>> propertyExpression,
        Func<TInput, string> getZipCodeFunction
    )
    {
        fluentValidationValidatorWrapper.RuleFor(q => propertyExpression)
            .Must((input, zipCode) => addressValueObjectSpecifications.AddressValueObjectShouldHaveZipCodeMaximumLength(getZipCodeFunction(input)))
            .When(input => addressValueObjectSpecifications.AddressValueObjectShouldHaveZipCode(getZipCodeFunction(input)))
            .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveZipCodeMaximumLengthErrorCode)
            .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveZipCodeMaximumLengthMessage)
            .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveZipCodeMaximumLengthSeverity);

    }
}