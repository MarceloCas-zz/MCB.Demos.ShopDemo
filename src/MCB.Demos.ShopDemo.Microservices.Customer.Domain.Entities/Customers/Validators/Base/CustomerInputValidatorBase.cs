using FluentValidation;
using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;
using MCB.Core.Domain.Entities.DomainEntitiesBase.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces;
using System.Linq.Expressions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Base
{
    public abstract class CustomerInputValidatorBase<TInputBase>
        : InputBaseValidator<TInputBase>
        where TInputBase : InputBase
    {
        // Properties
        protected ICustomerSpecifications CustomerSpecifications { get; }

        // Constructors
        protected CustomerInputValidatorBase(ICustomerSpecifications customerSpecifications)
        {
            CustomerSpecifications = customerSpecifications;
        }

        // Protected Methods
        protected void AddCustomerShouldHaveFirstName<TProperty>(
            FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
            Expression<Func<TInputBase, TProperty>> propertyExpression,
            Func<TInputBase, string> getFirstNameFunction
        )
        {
            fluentValidationValidatorWrapper.RuleFor(propertyExpression)
                .Must((input, firstName) => CustomerSpecifications.CustomerShouldHaveFirstName(getFirstNameFunction(input)))
                .WithErrorCode(ICustomerSpecifications.CustomerShouldHaveFirstNameErrorCode)
                .WithMessage(ICustomerSpecifications.CustomerShouldHaveFirstNameMessage)
                .WithSeverity(ICustomerSpecifications.CustomerShouldHaveFirstNameSeverity);
        }
        protected void AddCustomerShouldHaveFirstNameMaximumLength<TProperty>(
            FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
            Expression<Func<TInputBase, TProperty>> propertyExpression,
            Func<TInputBase, string> getFirstNameFunction
        )
        {
            fluentValidationValidatorWrapper.RuleFor(propertyExpression)
                .Must((input, firstName) => CustomerSpecifications.CustomerShouldHaveFirstNameMaximumLength(getFirstNameFunction(input)))
                .When(input => CustomerSpecifications.CustomerShouldHaveFirstName(getFirstNameFunction(input)))
                .WithErrorCode(ICustomerSpecifications.CustomerShouldHaveFirstNameMaximumLengthErrorCode)
                .WithMessage(ICustomerSpecifications.CustomerShouldHaveFirstNameMaximumLengthMessage)
                .WithSeverity(ICustomerSpecifications.CustomerShouldHaveFirstNameMaximumLengthSeverity);
        }

        protected void AddCustomerShouldHaveLastName<TProperty>(
            FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
            Expression<Func<TInputBase, TProperty>> propertyExpression,
            Func<TInputBase, string> getLastNameFunction
        )
        {
            fluentValidationValidatorWrapper.RuleFor(propertyExpression)
                .Must((input, firstName) => CustomerSpecifications.CustomerShouldHaveLastName(getLastNameFunction(input)))
                .WithErrorCode(ICustomerSpecifications.CustomerShouldHaveLastNameErrorCode)
                .WithMessage(ICustomerSpecifications.CustomerShouldHaveLastNameMessage)
                .WithSeverity(ICustomerSpecifications.CustomerShouldHaveLastNameSeverity);
        }
        protected void AddCustomerShouldHaveLastNameMaximumLength<TProperty>(
            FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
            Expression<Func<TInputBase, TProperty>> propertyExpression,
            Func<TInputBase, string> getLastNameFunction
        )
        {
            fluentValidationValidatorWrapper.RuleFor(propertyExpression)
                .Must((input, firstName) => CustomerSpecifications.CustomerShouldHaveLastNameMaximumLength(getLastNameFunction(input)))
                .When(input => CustomerSpecifications.CustomerShouldHaveLastName(getLastNameFunction(input)))
                .WithErrorCode(ICustomerSpecifications.CustomerShouldHaveLastNameMaximumLengthErrorCode)
                .WithMessage(ICustomerSpecifications.CustomerShouldHaveLastNameMaximumLengthMessage)
                .WithSeverity(ICustomerSpecifications.CustomerShouldHaveLastNameMaximumLengthSeverity);
        }

        protected void AddCustomerShouldHaveBirthDate<TProperty>(
            FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
            Expression<Func<TInputBase, TProperty>> propertyExpression,
            Func<TInputBase, DateOnly> getBirthDateFunction
        )
        {
            fluentValidationValidatorWrapper.RuleFor(propertyExpression)
                .Must((input, firstName) => CustomerSpecifications.CustomerShouldHaveBirthDate(getBirthDateFunction(input)))
                .WithErrorCode(ICustomerSpecifications.CustomerShouldHaveLastNameErrorCode)
                .WithMessage(ICustomerSpecifications.CustomerShouldHaveLastNameMessage)
                .WithSeverity(ICustomerSpecifications.CustomerShouldHaveLastNameSeverity);
        }
        protected void AddCustomerShouldHaveValidBirthDate<TProperty>(
            FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
            Expression<Func<TInputBase, TProperty>> propertyExpression,
            Func<TInputBase, DateOnly> getBirthDateFunction
        )
        {
            fluentValidationValidatorWrapper.RuleFor(propertyExpression)
                .Must((input, firstName) => CustomerSpecifications.CustomerShouldHaveValidBirthDate(getBirthDateFunction(input)))
                .When(input => CustomerSpecifications.CustomerShouldHaveBirthDate(getBirthDateFunction(input)))
                .WithErrorCode(ICustomerSpecifications.CustomerShouldHaveLastNameMaximumLengthErrorCode)
                .WithMessage(ICustomerSpecifications.CustomerShouldHaveLastNameMaximumLengthMessage)
                .WithSeverity(ICustomerSpecifications.CustomerShouldHaveLastNameMaximumLengthSeverity);
        }
    }
}
