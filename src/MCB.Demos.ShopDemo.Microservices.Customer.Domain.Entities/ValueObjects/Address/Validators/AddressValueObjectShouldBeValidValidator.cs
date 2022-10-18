using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address.Validators.Wrappers;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address.Validators;

public sealed class AddressValueObjectShouldBeValidValidator
    : ValidatorBase<AddressValueObject>,
    IAddressValueObjectShouldBeValidValidator
{
    // Fields
    private readonly IAddressValueObjectSpecifications _addressValueObjectSpecifications;

    // Constructors
    public AddressValueObjectShouldBeValidValidator(
        IAddressValueObjectSpecifications addressValueObjectSpecifications
    )
    {
        _addressValueObjectSpecifications = addressValueObjectSpecifications;
    }

    // Protected Methods
    protected override void ConfigureFluentValidationConcreteValidator(FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
    {
        // Address Value Object - Street
        AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveStreet(
            _addressValueObjectSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q.Street,
            getStreetFunction: q => q.Street
        );
        AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveStreetMaximumLength(
            _addressValueObjectSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q.Street,
            getStreetFunction: q => q.Street
        );

        // Address Value Object - Number
        AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveNumber(
            _addressValueObjectSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q.Number,
            getNumberFunction: q => q.Number
        );
        AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveNumberMaximumLength(
            _addressValueObjectSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q.Number,
            getNumberFunction: q => q.Number
        );

        // Address Value Object - City
        AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveCity(
            _addressValueObjectSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q.City,
            getCityFunction: q => q.City
        );
        AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveCityMaximumLength(
            _addressValueObjectSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q.City,
            getCityFunction: q => q.City
        );

        // Address Value Object - State
        AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveState(
            _addressValueObjectSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q.State,
            getStateFunction: q => q.State
        );
        AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveStateMaximumLength(
            _addressValueObjectSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q.State,
            getStateFunction: q => q.State
        );

        // Address Value Object - Country
        AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveCountry(
            _addressValueObjectSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q.Country,
            getCountryFunction: q => q.Country
        );
        AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveCountryMaximumLength(
            _addressValueObjectSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q.Country,
            getCountryFunction: q => q.Country
        );

        // Address Value Object - ZipCode
        AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveZipCode(
            _addressValueObjectSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q.ZipCode,
            getZipCodeFunction: q => q.ZipCode
        );
        AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveZipCodeMaximumLength(
            _addressValueObjectSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q.ZipCode,
            getZipCodeFunction: q => q.ZipCode
        );
    }
}