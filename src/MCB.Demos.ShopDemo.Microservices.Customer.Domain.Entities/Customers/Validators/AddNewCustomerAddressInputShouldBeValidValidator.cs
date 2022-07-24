using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators
{
    public class AddNewCustomerAddressInputShouldBeValidValidator
        : CustomerAddressInputValidatorBase<AddNewCustomerAddressInput>,
        IAddNewCustomerAddressInputShouldBeValidValidator
    {
        // Constructors
        public AddNewCustomerAddressInputShouldBeValidValidator(
            ICustomerAddressSpecifications customerAddressSpecifications
        ) : base(customerAddressSpecifications)
        {
        }

        // Configure
        protected override void ConfigureFluentValidationConcreteValidatorInternal(ValidatorBase<AddNewCustomerAddressInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
        {
            AddCustomerAddressShouldHaveCustomerAddressType(
                fluentValidationValidatorWrapper,
                propertyExpression: input => input.CustomerAddressType,
                getCustomerAddressTypeFunction: input => input.CustomerAddressType
            );

            AddCustomerAddressShouldHaveAddressValueObject(
                fluentValidationValidatorWrapper,
                propertyExpression: input => input.AddressValueObject,
                getAddressValueObjectFunction: input => input.AddressValueObject
            );
        }
    }
}
