using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Email.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Email.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Email.Validators.Wrappers;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Email.Validators;

public class EmailValueObjectShouldBeValidValidator
    : ValidatorBase<EmailValueObject>,
    IEmailValueObjectShouldBeValidValidator
{
    // Fields
    private readonly IEmailValueObjectSpecifications _emailValueObjectSpecifications;

    // Constructors
    public EmailValueObjectShouldBeValidValidator(
        IEmailValueObjectSpecifications emailValueObjectSpecifications
    )
    {
        _emailValueObjectSpecifications = emailValueObjectSpecifications;
    }

    // Protected Methods
    protected override void ConfigureFluentValidationConcreteValidator(FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
    {
        EmailValueObjectValidatorWrapper.AddEmailValueObjectShouldRequired(
            _emailValueObjectSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q,
            getEmailFunction: q => q
        );
        EmailValueObjectValidatorWrapper.AddEmailValueObjectShouldHaveMaximumLength(
            _emailValueObjectSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q,
            getEmailFunction: q => q
        );
    }
}