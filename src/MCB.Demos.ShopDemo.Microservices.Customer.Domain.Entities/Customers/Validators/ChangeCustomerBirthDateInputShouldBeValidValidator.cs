using FluentValidation;
using MCB.Core.Domain.Entities.DomainEntitiesBase.Validators;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators
{
    public class ChangeCustomerBirthDateInputShouldBeValidValidator
        : InputBaseValidator<ChangeCustomerBirthDateInput>,
        IChangeCustomerBirthDateInputShouldBeValidValidator
    {
        // Fields
        private readonly ICustomerSpecifications _customerSpecifications;

        // Constructors
        public ChangeCustomerBirthDateInputShouldBeValidValidator(
            ICustomerSpecifications customerSpecifications
        ) : base()
        {
            _customerSpecifications = customerSpecifications;
        }

        // Configure
        protected override void ConfigureFluentValidationConcreteValidatorInternal(ValidatorBase<ChangeCustomerBirthDateInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
        {
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
