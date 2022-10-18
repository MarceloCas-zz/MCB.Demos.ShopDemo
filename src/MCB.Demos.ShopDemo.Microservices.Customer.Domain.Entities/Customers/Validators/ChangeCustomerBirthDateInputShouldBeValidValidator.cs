using MCB.Core.Domain.Entities.DomainEntitiesBase.Validators;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Wrappers;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators;

public sealed class ChangeCustomerBirthDateInputShouldBeValidValidator
    : InputBaseValidator<ChangeCustomerBirthDateInput>,
    IChangeCustomerBirthDateInputShouldBeValidValidator
{
    // Fields
    private readonly ICustomerSpecifications _customerSpecifications;

    // Constructors
    public ChangeCustomerBirthDateInputShouldBeValidValidator(
        ICustomerSpecifications customerSpecifications
    )
    {
        _customerSpecifications = customerSpecifications;
    }

    // Protected Methods
    protected override void ConfigureFluentValidationConcreteValidatorInternal(ValidatorBase<ChangeCustomerBirthDateInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
    {
        CustomerValidatorWrapper.AddCustomerShouldHaveBirthDate(
            _customerSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: input => input.BirthDate,
            getBirthDateFunction: input => input.BirthDate
        );
        CustomerValidatorWrapper.AddCustomerShouldHaveValidBirthDate(
            _customerSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: input => input.BirthDate,
            getBirthDateFunction: input => input.BirthDate
        );
    }
}