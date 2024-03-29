﻿using FluentValidation;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Email.Specifications.Interfaces;
using System.Linq.Expressions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Email.Validators.Wrappers;

public class EmailValueObjectValidatorWrapper
{
    // Street
    public static void AddEmailValueObjectShouldRequired<TInput, TProperty>(
        IEmailValueObjectSpecifications emailValueObjectSpecifications,
        ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
        Expression<Func<TInput, TProperty>> propertyExpression,
        Func<TInput, EmailValueObject> getEmailFunction
    )
    {
        fluentValidationValidatorWrapper.RuleFor(propertyExpression)
            .Must((emailValueObject, street) => emailValueObjectSpecifications.EmailValueObjectShouldRequired(getEmailFunction(emailValueObject)))
            .WithErrorCode(IEmailValueObjectSpecifications.EmailValueObjectShouldRequiredErrorCode)
            .WithMessage(IEmailValueObjectSpecifications.EmailValueObjectShouldRequiredMessage)
            .WithSeverity(IEmailValueObjectSpecifications.EmailValueObjectShouldRequiredSeverity);
    }
    public static void AddEmailValueObjectShouldHaveMaximumLength<TInput, TProperty>(
        IEmailValueObjectSpecifications emailValueObjectSpecifications,
        ValidatorBase<TInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
        Expression<Func<TInput, TProperty>> propertyExpression,
        Func<TInput, EmailValueObject> getEmailFunction
    )
    {
        fluentValidationValidatorWrapper.RuleFor(q => propertyExpression)
            .Must((input, street) => emailValueObjectSpecifications.EmailValueObjectShouldHaveMaximumLength(getEmailFunction(input)))
            .When(input => emailValueObjectSpecifications.EmailValueObjectShouldRequired(getEmailFunction(input)))
            .WithErrorCode(IEmailValueObjectSpecifications.EmailValueObjectShouldHaveMaximumLengthErrorCode)
            .WithMessage(IEmailValueObjectSpecifications.EmailValueObjectShouldHaveMaximumLengthMessage)
            .WithSeverity(IEmailValueObjectSpecifications.EmailValueObjectShouldHaveMaximumLengthSeverity);

    }
}