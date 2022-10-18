using MCB.Core.Domain.Entities.DomainEntitiesBase.Validators;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Wrappers;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators;

public sealed class RemoveCustomerAddressInputShouldBeValidValidator
    : InputBaseValidator<RemoveCustomerAddressInput>,
    IRemoveCustomerAddressInputShouldBeValidValidator
{
    // Fields
    private readonly ICustomerAddressSpecifications _customerAddressSpecifications;

    // Constructors
    public RemoveCustomerAddressInputShouldBeValidValidator(
        ICustomerAddressSpecifications customerAddressSpecifications
    )
    {
        _customerAddressSpecifications = customerAddressSpecifications;
    }

    // Protected Methods
    protected override void ConfigureFluentValidationConcreteValidatorInternal(ValidatorBase<RemoveCustomerAddressInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
    {
        CustomerAddressValidatorWrapper.AddCustomerAddressShouldHaveId(
            _customerAddressSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q.CustomerAddressId,
            getIdFunction: q => q.CustomerAddressId
        );
    }
}