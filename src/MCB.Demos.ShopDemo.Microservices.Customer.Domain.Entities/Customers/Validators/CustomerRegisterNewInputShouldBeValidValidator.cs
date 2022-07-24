﻿using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using FluentValidation;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;
using MCB.Core.Domain.Entities.DomainEntitiesBase.Validators;
using MCB.Core.Domain.Entities.Abstractions.Specifications.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators
{
    public class CustomerRegisterNewInputShouldBeValidValidator
        : InputBaseValidator<RegisterNewCustomerInput>,
        ICustomerRegisterNewInputShouldBeValidValidator
    {
        // FirstName
        public static readonly string CustomerShouldHaveFirstNameErrorCode = nameof(CustomerShouldHaveFirstNameErrorCode);
        public static readonly string CustomerShouldHaveFirstNameMessage = nameof(CustomerShouldHaveFirstNameMessage);
        public static readonly Severity CustomerShouldHaveFirstNameSeverity = Severity.Error;

        public static readonly string CustomerShouldHaveFirstNameMaximumLengthErrorCode = nameof(CustomerShouldHaveFirstNameMaximumLengthErrorCode);
        public static readonly string CustomerShouldHaveFirstNameMaximumLengthMessage = nameof(CustomerShouldHaveFirstNameMaximumLengthMessage);
        public static readonly Severity CustomerShouldHaveFirstNameMaximumLengthSeverity = Severity.Error;

        // LastName
        public static readonly string CustomerShouldHaveLastNameErrorCode = nameof(CustomerShouldHaveLastNameErrorCode);
        public static readonly string CustomerShouldHaveLastNameMessage = nameof(CustomerShouldHaveLastNameMessage);
        public static readonly Severity CustomerShouldHaveLastNameSeverity = Severity.Error;

        public static readonly string CustomerShouldHaveLastNameMaximumLengthErrorCode = nameof(CustomerShouldHaveLastNameMaximumLengthErrorCode);
        public static readonly string CustomerShouldHaveLastNameMaximumLengthMessage = nameof(CustomerShouldHaveLastNameMaximumLengthMessage);
        public static readonly Severity CustomerShouldHaveLastNameMaximumLengthSeverity = Severity.Error;

        // BirthDate
        public static readonly string CustomerShouldHaveBirthDateErrorCode = nameof(CustomerShouldHaveBirthDateErrorCode);
        public static readonly string CustomerShouldHaveBirthDateMessage = nameof(CustomerShouldHaveBirthDateMessage);
        public static readonly Severity CustomerShouldHaveBirthDateSeverity = Severity.Error;

        // Constructors
        public CustomerRegisterNewInputShouldBeValidValidator(
            IDomainEntitySpecifications domainEntitySpecifications
        ) : base(domainEntitySpecifications)
        {

        }

        // Configure
        protected override void ConfigureFluentValidationConcreteValidatorInternal(FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
        {
            fluentValidationValidatorWrapper.RuleFor(input => input.FirstName)
                .NotEmpty()
                .WithErrorCode(CustomerShouldHaveFirstNameErrorCode)
                .WithMessage(CustomerShouldHaveFirstNameMessage)
                .WithSeverity(CustomerShouldHaveFirstNameSeverity)
                .MaximumLength(150)
                .WithErrorCode(CustomerShouldHaveFirstNameMaximumLengthErrorCode)
                .WithMessage(CustomerShouldHaveFirstNameMaximumLengthMessage)
                .WithSeverity(CustomerShouldHaveFirstNameMaximumLengthSeverity);

            fluentValidationValidatorWrapper.RuleFor(input => input.LastName)
                .NotEmpty()
                .WithErrorCode(CustomerShouldHaveLastNameErrorCode)
                .WithMessage(CustomerShouldHaveLastNameMessage)
                .WithSeverity(CustomerShouldHaveLastNameSeverity)
                .MaximumLength(150)
                .WithErrorCode(CustomerShouldHaveLastNameMaximumLengthErrorCode)
                .WithMessage(CustomerShouldHaveLastNameMaximumLengthMessage)
                .WithSeverity(CustomerShouldHaveLastNameMaximumLengthSeverity);

            fluentValidationValidatorWrapper.RuleFor(input => input.BirthDate)
                .GreaterThan(default(DateOnly))
                .WithErrorCode(CustomerShouldHaveBirthDateErrorCode)
                .WithMessage(CustomerShouldHaveBirthDateMessage)
                .WithSeverity(CustomerShouldHaveBirthDateSeverity);
        }
    }
}