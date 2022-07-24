using FluentValidation;
using MCB.Core.Domain.Entities.DomainEntitiesBase.Validators;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators
{
    public class AddNewCustomerAddressInputShouldBeValidValidator
        : InputBaseValidator<AddNewCustomerAddressInput>,
        IAddNewCustomerAddressInputShouldBeValidValidator
    {
        // Fields
        private readonly ICustomerAddressSpecifications _customerAddressSpecifications;

        // Constructors
        public AddNewCustomerAddressInputShouldBeValidValidator(
            ICustomerAddressSpecifications customerAddressSpecifications
        ) : base()
        {
            _customerAddressSpecifications = customerAddressSpecifications;
        }

        // Configure
        protected override void ConfigureFluentValidationConcreteValidatorInternal(ValidatorBase<AddNewCustomerAddressInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
        {
            fluentValidationValidatorWrapper.RuleFor(input => input.CustomerAddressType)
                .Must(customerAddressType => _customerAddressSpecifications.CustomerAddressShouldHaveCustomerAddressType(customerAddressType))
                .WithErrorCode(ICustomerAddressSpecifications.CustomerAddressShouldHaveCustomerAddressTypeErrorCode)
                .WithMessage(ICustomerAddressSpecifications.CustomerAddressShouldHaveCustomerAddressTypeMessage)
                .WithSeverity(ICustomerAddressSpecifications.CustomerAddressShouldHaveCustomerAddressTypeSeverity);

            fluentValidationValidatorWrapper.RuleFor(input => input.AddressValueObject)
                .Must(addressValueObject => _customerAddressSpecifications.CustomerAddressShouldHaveAddressValueObject(addressValueObject))
                .WithErrorCode(ICustomerAddressSpecifications.CustomerAddressShouldHaveAddressValueObjectErrorCode)
                .WithMessage(ICustomerAddressSpecifications.CustomerAddressShouldHaveAddressValueObjectMessage)
                .WithSeverity(ICustomerAddressSpecifications.CustomerAddressShouldHaveAddressValueObjectSeverity);
        }
    }
}
