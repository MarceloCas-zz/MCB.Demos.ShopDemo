using FluentValidation;
using MCB.Core.Domain.Entities.DomainEntitiesBase.Validators;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators
{
    public class ChangeCustomerNameInputShouldBeValidValidator
        : InputBaseValidator<ChangeCustomerNameInput>,
        IChangeCustomerNameInputShouldBeValidValidator
    {
        // Fields
        private readonly ICustomerSpecifications _customerSpecifications;

        // Constructors
        public ChangeCustomerNameInputShouldBeValidValidator(
            ICustomerSpecifications customerSpecifications
        ) : base()
        {
            _customerSpecifications = customerSpecifications;
        }

        // Configure
        protected override void ConfigureFluentValidationConcreteValidatorInternal(ValidatorBase<ChangeCustomerNameInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
        {
            fluentValidationValidatorWrapper.RuleFor(input => input.FirstName)
                .Must(firstName => _customerSpecifications.CustomerShouldHaveFirstName(firstName))
                .WithErrorCode(ICustomerSpecifications.CustomerShouldHaveFirstNameErrorCode)
                .WithMessage(ICustomerSpecifications.CustomerShouldHaveFirstNameMessage)
                .WithSeverity(ICustomerSpecifications.CustomerShouldHaveFirstNameSeverity);

            fluentValidationValidatorWrapper.RuleFor(input => input.FirstName)
                .Must(firstName => _customerSpecifications.CustomerShouldHaveFirstNameMaximumLength(firstName))
                .When(input => _customerSpecifications.CustomerShouldHaveFirstName(input.FirstName))
                .WithErrorCode(ICustomerSpecifications.CustomerShouldHaveFirstNameMaximumLengthErrorCode)
                .WithMessage(ICustomerSpecifications.CustomerShouldHaveFirstNameMaximumLengthMessage)
                .WithSeverity(ICustomerSpecifications.CustomerShouldHaveFirstNameMaximumLengthSeverity);

            fluentValidationValidatorWrapper.RuleFor(input => input.LastName)
                .Must(lastName => _customerSpecifications.CustomerShouldHaveLastName(lastName))
                .WithErrorCode(ICustomerSpecifications.CustomerShouldHaveLastNameErrorCode)
                .WithMessage(ICustomerSpecifications.CustomerShouldHaveLastNameMessage)
                .WithSeverity(ICustomerSpecifications.CustomerShouldHaveLastNameSeverity);

            fluentValidationValidatorWrapper.RuleFor(input => input.LastName)
                .Must(lastName => _customerSpecifications.CustomerShouldHaveLastNameMaximumLength(lastName))
                .When(input => _customerSpecifications.CustomerShouldHaveLastName(input.LastName))
                .WithErrorCode(ICustomerSpecifications.CustomerShouldHaveLastNameMaximumLengthErrorCode)
                .WithMessage(ICustomerSpecifications.CustomerShouldHaveLastNameMaximumLengthMessage)
                .WithSeverity(ICustomerSpecifications.CustomerShouldHaveLastNameMaximumLengthSeverity);
        }
    }
}
