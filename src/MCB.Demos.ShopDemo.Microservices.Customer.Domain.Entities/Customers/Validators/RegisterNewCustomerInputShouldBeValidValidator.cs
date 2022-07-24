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
                .WithSeverity(ICustomerSpecifications.CustomerShouldHaveFirstNameSeverity)

                .Must(firstName => _customerSpecifications.CustomerShouldHaveFirstNameMaximumLength(firstName))
                .WithErrorCode(ICustomerSpecifications.CustomerShouldHaveFirstNameMaximumLengthErrorCode)
                .WithMessage(ICustomerSpecifications.CustomerShouldHaveFirstNameMaximumLengthMessage)
                .WithSeverity(ICustomerSpecifications.CustomerShouldHaveFirstNameMaximumLengthSeverity);

            fluentValidationValidatorWrapper.RuleFor(input => input.LastName)
                .Must(lastName => _customerSpecifications.CustomerShouldHaveLastName(lastName))
                .WithErrorCode(ICustomerSpecifications.CustomerShouldHaveLastNameErrorCode)
                .WithMessage(ICustomerSpecifications.CustomerShouldHaveLastNameMessage)
                .WithSeverity(ICustomerSpecifications.CustomerShouldHaveLastNameSeverity)

                .Must(lastName => _customerSpecifications.CustomerShouldHaveLastNameMaximumLength(lastName))
                .WithErrorCode(ICustomerSpecifications.CustomerShouldHaveLastNameMaximumLengthErrorCode)
                .WithMessage(ICustomerSpecifications.CustomerShouldHaveLastNameMaximumLengthMessage)
                .WithSeverity(ICustomerSpecifications.CustomerShouldHaveLastNameMaximumLengthSeverity);

            fluentValidationValidatorWrapper.RuleFor(input => input.BirthDate)
                .Must(birthDate => _customerSpecifications.CustomerShouldHaveBirthDate(birthDate))
                .WithErrorCode(ICustomerSpecifications.CustomerShouldHaveBirthDateErrorCode)
                .WithMessage(ICustomerSpecifications.CustomerShouldHaveBirthDateMessage)
                .WithSeverity(ICustomerSpecifications.CustomerShouldHaveBirthDateSeverity)

                .Must(birthDate => _customerSpecifications.CustomerShouldHaveValidBirthDate(birthDate))
                .WithErrorCode(ICustomerSpecifications.CustomerShouldHaveValidBirthDateErrorCode)
                .WithMessage(ICustomerSpecifications.CustomerShouldHaveValidBirthDateMessage)
                .WithSeverity(ICustomerSpecifications.CustomerShouldHaveValidBirthDateSeverity);
        }
    }
}
