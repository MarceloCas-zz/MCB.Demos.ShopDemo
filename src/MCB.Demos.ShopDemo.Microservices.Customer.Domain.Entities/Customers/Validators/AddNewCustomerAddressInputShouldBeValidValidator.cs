using MCB.Core.Domain.Entities.DomainEntitiesBase.Validators;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Wrappers;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators;

public sealed class AddNewCustomerAddressInputShouldBeValidValidator
    : InputBaseValidator<AddNewCustomerAddressInput>,
    IAddNewCustomerAddressInputShouldBeValidValidator
{
    // Fields
    private readonly ICustomerAddressSpecifications _customerAddressSpecifications;

    // Constructors
    public AddNewCustomerAddressInputShouldBeValidValidator(
        ICustomerAddressSpecifications customerAddressSpecifications
    )
    {
        _customerAddressSpecifications = customerAddressSpecifications;
    }

    // Protected Methods
    protected override void ConfigureFluentValidationConcreteValidatorInternal(ValidatorBase<AddNewCustomerAddressInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
    {
        CustomerAddressValidatorWrapper.AddCustomerAddressShouldHaveCustomerAddressType(
            _customerAddressSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q.CustomerAddressType,
            getCustomerAddressTypeFunction: q => q.CustomerAddressType
        );
        CustomerAddressValidatorWrapper.AddCustomerAddressShouldHaveAddressValueObject(
            _customerAddressSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q.CustomerAddressType,
            getAddressValueObjectFunction: q => q.AddressValueObject
        );
    }
}