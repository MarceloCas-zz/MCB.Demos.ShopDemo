using MCB.Core.Domain.Entities.DomainEntitiesBase.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Wrappers;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators;

internal sealed class CustomerAddressShouldBeValidValidator
    : DomainEntityBaseValidator<CustomerAddress>,
    ICustomerAddressShouldBeValidValidator
{
    // Fields
    private readonly ICustomerAddressSpecifications _customerAddressSpecifications;

    // Constructors
    internal CustomerAddressShouldBeValidValidator(
        ICustomerAddressSpecifications customerAddressSpecifications
    )
    {
        _customerAddressSpecifications = customerAddressSpecifications;
    }

    // Protected Methods
    protected override void ConfigureFluentValidationConcreteValidatorInternal(FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
    {
        CustomerAddressValidatorWrapper.AddCustomerAddressShouldHaveAddressValueObject(
            _customerAddressSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q.AddressValueObject,
            getAddressValueObjectFunction: q => q.AddressValueObject
        );
        CustomerAddressValidatorWrapper.AddCustomerAddressShouldHaveCustomerAddressType(
            _customerAddressSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q.CustomerAddressType,
            getCustomerAddressTypeFunction: q => q.CustomerAddressType
        );
    }
}