using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators.Wrappers;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators;

public sealed class CustomerAddressInfoShouldHaveCustomerAddressValidator
    : ValidatorBase<(Guid customerAddressId, IEnumerable<CustomerAddress> customerAddressCollection)>,
    ICustomerAddressInfoShouldHaveCustomerAddressValidator
{
    // Fields
    private readonly ICustomerAddressInfoSpecifications _customerAddressInfoSpecifications;

    // Constructors
    public CustomerAddressInfoShouldHaveCustomerAddressValidator(
        ICustomerAddressInfoSpecifications customerAddressInfoSpecifications
    )
    {
        _customerAddressInfoSpecifications = customerAddressInfoSpecifications;
    }

    // Protected Methods
    protected override void ConfigureFluentValidationConcreteValidator(FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
    {
        CustomerAddressInfoValidatorWrapper.AddCustomerAddressInfoShouldHaveCustomerAddressInCustomerAddressCollection(
            _customerAddressInfoSpecifications,
            fluentValidationValidatorWrapper,
            propertyExpression: q => q.customerAddressId,
            getFunction: q => (q.customerAddressId, q.customerAddressCollection)
        );
    }
}