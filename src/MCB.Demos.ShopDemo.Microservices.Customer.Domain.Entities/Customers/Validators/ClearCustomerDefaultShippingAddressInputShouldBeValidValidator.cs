using MCB.Core.Domain.Entities.DomainEntitiesBase.Validators;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators;

public sealed class ClearCustomerDefaultShippingAddressInputShouldBeValidValidator
    : InputBaseValidator<ClearCustomerDefaultShippingAddressInput>,
    IClearCustomerDefaultShippingAddressInputShouldBeValidValidator
{
    // Protected Methods
    protected override void ConfigureFluentValidationConcreteValidatorInternal(ValidatorBase<ClearCustomerDefaultShippingAddressInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
    {

    }
}