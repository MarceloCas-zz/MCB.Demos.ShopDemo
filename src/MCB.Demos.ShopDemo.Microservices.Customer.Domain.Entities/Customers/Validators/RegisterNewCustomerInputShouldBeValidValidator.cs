using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using FluentValidation;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;
using MCB.Core.Domain.Entities.DomainEntitiesBase.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators
{
    public class RegisterNewCustomerInputShouldBeValidValidator
        : InputBaseValidator<RegisterNewCustomerInput>,
        IRegisterNewCustomerInputShouldBeValidValidator
    {
        // Fields
        private readonly ICustomerSpecifications _customerSpecifications;

        // Constructors
        public RegisterNewCustomerInputShouldBeValidValidator(
            ICustomerSpecifications customerSpecifications
        ) : base()
        {
            _customerSpecifications = customerSpecifications;
        }

        // Configure
        protected override void ConfigureFluentValidationConcreteValidatorInternal(FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
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

            fluentValidationValidatorWrapper.RuleFor(input => input.BirthDate)
                .Must(birthDate => _customerSpecifications.CustomerShouldHaveBirthDate(birthDate))
                .WithErrorCode(ICustomerSpecifications.CustomerShouldHaveBirthDateErrorCode)
                .WithMessage(ICustomerSpecifications.CustomerShouldHaveBirthDateMessage)
                .WithSeverity(ICustomerSpecifications.CustomerShouldHaveBirthDateSeverity);

            fluentValidationValidatorWrapper.RuleFor(input => input.BirthDate)
                .Must(birthDate => _customerSpecifications.CustomerShouldHaveValidBirthDate(birthDate))
                .When(input => _customerSpecifications.CustomerShouldHaveBirthDate(input.BirthDate))
                .WithErrorCode(ICustomerSpecifications.CustomerShouldHaveValidBirthDateErrorCode)
                .WithMessage(ICustomerSpecifications.CustomerShouldHaveValidBirthDateMessage)
                .WithSeverity(ICustomerSpecifications.CustomerShouldHaveValidBirthDateSeverity);
        }
    }
}
