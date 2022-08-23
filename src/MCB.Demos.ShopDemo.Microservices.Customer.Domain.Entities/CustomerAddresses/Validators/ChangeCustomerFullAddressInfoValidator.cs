using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Wrappers;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators
{
    public class ChangeCustomerFullAddressInfoValidator
        : ValidatorBase<ChangeCustomerFullAddressInfoInput>,
        IChangeCustomerFullAddressInfoValidator
    {
        // Fields
        private readonly ICustomerAddressSpecifications _customerAddressSpecifications;

        // Constructors
        public ChangeCustomerFullAddressInfoValidator(
            ICustomerAddressSpecifications customerAddressSpecifications
        )
        {
            _customerAddressSpecifications = customerAddressSpecifications;
        }

        // Protected Methods
        protected override void ConfigureFluentValidationConcreteValidator(FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
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
}
