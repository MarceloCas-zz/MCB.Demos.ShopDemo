using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Models;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Wrappers;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators
{
    public class ChangeCustomerAddressTypeValidator
        : ValidatorBase<ChangeCustomerAddressTypeInput>,
        IChangeCustomerAddressTypeValidator
    {
        // Fields
        private readonly ICustomerAddressSpecifications _customerAddressSpecifications;

        // Constructors
        public ChangeCustomerAddressTypeValidator(
            ICustomerAddressSpecifications customerAddressSpecifications
        )
        {
            _customerAddressSpecifications = customerAddressSpecifications;
        }

        // Protected Methods
        protected override void ConfigureFluentValidationConcreteValidator(FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
        {
            CustomerAddressValidatorWrapper.AddCustomerAddressShouldHaveCustomerAddressType(
                _customerAddressSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: q => q.CustomerAddressType,
                getCustomerAddressTypeFunction: q => q.CustomerAddressType
            );
        }
    }
}
