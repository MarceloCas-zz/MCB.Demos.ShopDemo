using FluentValidation;
using MCB.Core.Domain.Entities.DomainEntitiesBase.Validators;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators
{
    public class ChangeBirthDateInputShouldBeValidValidator
        : InputBaseValidator<ChangeBirthDateInput>,
        IChangeBirthDateInputShouldBeValidValidator
    {
        // Fields
        private readonly ICustomerSpecifications _customerSpecifications;

        // Constructors
        public ChangeBirthDateInputShouldBeValidValidator(
            ICustomerSpecifications customerSpecifications
        ) : base(customerSpecifications)
        {
            _customerSpecifications = customerSpecifications;
        }

        // Configure
        protected override void ConfigureFluentValidationConcreteValidatorInternal(ValidatorBase<ChangeBirthDateInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
        {
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
