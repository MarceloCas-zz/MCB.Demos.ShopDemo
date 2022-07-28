using FluentValidation;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators
{
    public class AddNewCustomerAddressInputShouldBeValidValidator
        : CustomerAddressInputValidatorBase<AddNewCustomerAddressInput>,
        IAddNewCustomerAddressInputShouldBeValidValidator
    {
        // Fields
        private readonly IAddressValueObjectSpecifications _addressValueObjectSpecifications;

        // Constructors
        public AddNewCustomerAddressInputShouldBeValidValidator(
            ICustomerAddressSpecifications customerAddressSpecifications,
            IAddressValueObjectSpecifications addressValueObjectSpecifications
        ) : base(customerAddressSpecifications)
        {
            _addressValueObjectSpecifications = addressValueObjectSpecifications;
        }

        // Configure
        protected override void ConfigureFluentValidationConcreteValidatorInternal(ValidatorBase<AddNewCustomerAddressInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
        {
            AddCustomerAddressShouldHaveCustomerAddressType(
                fluentValidationValidatorWrapper,
                propertyExpression: input => input.CustomerAddressType,
                getCustomerAddressTypeFunction: input => input.CustomerAddressType
            );

            AddCustomerAddressShouldHaveAddressValueObject(
                fluentValidationValidatorWrapper,
                propertyExpression: input => input.AddressValueObject,
                getAddressValueObjectFunction: input => input.AddressValueObject
            );

            fluentValidationValidatorWrapper.RuleFor(q => q.AddressValueObject.Street)
                .Must((input, street) => _addressValueObjectSpecifications.AddressValueObjectShouldHaveStreet(street))
                .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStreetErrorCode)
                .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStreetMessage)
                .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStreetSeverity);
            fluentValidationValidatorWrapper.RuleFor(q => q.AddressValueObject.Street)
                .Must((input, street) => _addressValueObjectSpecifications.AddressValueObjectShouldHaveStreetMaximumLength(street))
                .When(input => _addressValueObjectSpecifications.AddressValueObjectShouldHaveStreet(input.AddressValueObject.Street))
                .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStreetMaximumLengthErrorCode)
                .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStreetMaximumLengthMessage)
                .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStreetMaximumLengthSeverity);

            fluentValidationValidatorWrapper.RuleFor(q => q.AddressValueObject.Number)
                .Must((input, street) => _addressValueObjectSpecifications.AddressValueObjectShouldHaveNumber(street))
                .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveNumberErrorCode)
                .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveNumberMessage)
                .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveNumberSeverity);
            fluentValidationValidatorWrapper.RuleFor(q => q.AddressValueObject.Number)
                .Must((input, street) => _addressValueObjectSpecifications.AddressValueObjectShouldHaveNumberMaximumLength(street))
                .When(input => _addressValueObjectSpecifications.AddressValueObjectShouldHaveNumber(input.AddressValueObject.Number))
                .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveNumberMaximumLengthErrorCode)
                .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveNumberMaximumLengthMessage)
                .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveNumberMaximumLengthSeverity);

            fluentValidationValidatorWrapper.RuleFor(q => q.AddressValueObject.City)
                .Must((input, street) => _addressValueObjectSpecifications.AddressValueObjectShouldHaveCity(street))
                .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCityErrorCode)
                .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCityMessage)
                .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCitySeverity);
            fluentValidationValidatorWrapper.RuleFor(q => q.AddressValueObject.City)
                .Must((input, street) => _addressValueObjectSpecifications.AddressValueObjectShouldHaveCityMaximumLength(street))
                .When(input => _addressValueObjectSpecifications.AddressValueObjectShouldHaveCity(input.AddressValueObject.City))
                .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCityMaximumLengthErrorCode)
                .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCityMaximumLengthMessage)
                .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCityMaximumLengthSeverity);

            fluentValidationValidatorWrapper.RuleFor(q => q.AddressValueObject.State)
                .Must((input, street) => _addressValueObjectSpecifications.AddressValueObjectShouldHaveState(street))
                .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStateErrorCode)
                .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStateMessage)
                .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStateSeverity);
            fluentValidationValidatorWrapper.RuleFor(q => q.AddressValueObject.State)
                .Must((input, street) => _addressValueObjectSpecifications.AddressValueObjectShouldHaveStateMaximumLength(street))
                .When(input => _addressValueObjectSpecifications.AddressValueObjectShouldHaveState(input.AddressValueObject.State))
                .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStateMaximumLengthErrorCode)
                .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStateMaximumLengthMessage)
                .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveStateMaximumLengthSeverity);

            fluentValidationValidatorWrapper.RuleFor(q => q.AddressValueObject.Country)
                .Must((input, street) => _addressValueObjectSpecifications.AddressValueObjectShouldHaveCountry(street))
                .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCountryErrorCode)
                .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCountryMessage)
                .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCountrySeverity);
            fluentValidationValidatorWrapper.RuleFor(q => q.AddressValueObject.Country)
                .Must((input, street) => _addressValueObjectSpecifications.AddressValueObjectShouldHaveCountryMaximumLength(street))
                .When(input => _addressValueObjectSpecifications.AddressValueObjectShouldHaveCountry(input.AddressValueObject.Country))
                .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCountryMaximumLengthErrorCode)
                .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCountryMaximumLengthMessage)
                .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveCountryMaximumLengthSeverity);

            fluentValidationValidatorWrapper.RuleFor(q => q.AddressValueObject.ZipCode)
                .Must((input, street) => _addressValueObjectSpecifications.AddressValueObjectShouldHaveZipCode(street))
                .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveZipCodeErrorCode)
                .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveZipCodeMessage)
                .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveZipCodeSeverity);
            fluentValidationValidatorWrapper.RuleFor(q => q.AddressValueObject.ZipCode)
                .Must((input, street) => _addressValueObjectSpecifications.AddressValueObjectShouldHaveZipCodeMaximumLength(street))
                .When(input => _addressValueObjectSpecifications.AddressValueObjectShouldHaveZipCode(input.AddressValueObject.ZipCode))
                .WithErrorCode(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveZipCodeMaximumLengthErrorCode)
                .WithMessage(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveZipCodeMaximumLengthMessage)
                .WithSeverity(IAddressValueObjectSpecifications.AddressValueObjectShouldHaveZipCodeMaximumLengthSeverity);
        }
    }
}
