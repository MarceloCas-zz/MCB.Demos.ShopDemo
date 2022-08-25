using MCB.Core.Domain.Entities.DomainEntitiesBase.Validators;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Wrappers;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.AddressValueObjects.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.AddressValueObjects.Validators.Wrappers;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators
{
    public class AddNewCustomerAddressInputShouldBeValidValidator
        : InputBaseValidator<AddNewCustomerAddressInput>,
        IAddNewCustomerAddressInputShouldBeValidValidator
    {
        // Fields
        private readonly ICustomerAddressSpecifications _customerAddressSpecifications;
        private readonly IAddressValueObjectSpecifications _addressValueObjectSpecifications;

        // Constructors
        public AddNewCustomerAddressInputShouldBeValidValidator(
            ICustomerAddressSpecifications customerAddressSpecifications,
            IAddressValueObjectSpecifications addressValueObjectSpecifications
        )
        {
            _customerAddressSpecifications = customerAddressSpecifications;
            _addressValueObjectSpecifications = addressValueObjectSpecifications;
        }

        // Protected Methods
        protected override void ConfigureFluentValidationConcreteValidatorInternal(ValidatorBase<AddNewCustomerAddressInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
        {
            CustomerAddressValidatorWrapper.AddCustomerAddressShouldHaveCustomerAddressType(
                _customerAddressSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: q => q.CustomerAddressType,
                getCustomerAddressTypeFunction: q => q.CustomerAddressType
            );
            CustomerAddressValidatorWrapper.AddCustomerAddressShouldHaveAddressValueObject(
                _customerAddressSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: q => q.CustomerAddressType,
                getAddressValueObjectFunction: q => q.AddressValueObject
            );

            // Address Value Object - Street
            AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveStreet(
                _addressValueObjectSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: q => q.AddressValueObject.Street,
                getStreetFunction: q => q.AddressValueObject.Street
            );
            AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveStreetMaximumLength(
                _addressValueObjectSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: q => q.AddressValueObject.Street,
                getStreetFunction: q => q.AddressValueObject.Street
            );

            // Address Value Object - Number
            AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveNumber(
                _addressValueObjectSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: q => q.AddressValueObject.Number,
                getNumberFunction: q => q.AddressValueObject.Number
            );
            AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveNumberMaximumLength(
                _addressValueObjectSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: q => q.AddressValueObject.Number,
                getNumberFunction: q => q.AddressValueObject.Number
            );

            // Address Value Object - City
            AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveCity(
                _addressValueObjectSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: q => q.AddressValueObject.City,
                getCityFunction: q => q.AddressValueObject.City
            );
            AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveCityMaximumLength(
                _addressValueObjectSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: q => q.AddressValueObject.City,
                getCityFunction: q => q.AddressValueObject.City
            );

            // Address Value Object - State
            AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveState(
                _addressValueObjectSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: q => q.AddressValueObject.State,
                getStateFunction: q => q.AddressValueObject.State
            );
            AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveStateMaximumLength(
                _addressValueObjectSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: q => q.AddressValueObject.State,
                getStateFunction: q => q.AddressValueObject.State
            );

            // Address Value Object - Country
            AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveCountry(
                _addressValueObjectSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: q => q.AddressValueObject.Country,
                getCountryFunction: q => q.AddressValueObject.Country
            );
            AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveCountryMaximumLength(
                _addressValueObjectSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: q => q.AddressValueObject.Country,
                getCountryFunction: q => q.AddressValueObject.Country
            );

            // Address Value Object - ZipCode
            AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveZipCode(
                _addressValueObjectSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: q => q.AddressValueObject.ZipCode,
                getZipCodeFunction: q => q.AddressValueObject.ZipCode
            );
            AddressValueObjectValidatorWrapper.AddAddressValueObjectShouldHaveZipCodeMaximumLength(
                _addressValueObjectSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: q => q.AddressValueObject.ZipCode,
                getZipCodeFunction: q => q.AddressValueObject.ZipCode
            );
        }
    }
}
