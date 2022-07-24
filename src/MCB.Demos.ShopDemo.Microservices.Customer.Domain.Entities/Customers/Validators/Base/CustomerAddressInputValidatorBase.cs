using FluentValidation;
using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;
using MCB.Core.Domain.Entities.DomainEntitiesBase.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects;
using System.Linq.Expressions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Base
{
    public abstract class CustomerAddressInputValidatorBase<TInputBase>
        : InputBaseValidator<TInputBase>
        where TInputBase : InputBase
    {
        // Properties
        protected ICustomerAddressSpecifications CustomerAddressSpecifications { get; }

        // Constructors
        protected CustomerAddressInputValidatorBase(ICustomerAddressSpecifications customerAddressSpecifications)
        {
            CustomerAddressSpecifications = customerAddressSpecifications;
        }

        // Protected Methods
        protected void AddCustomerAddressShouldHaveCustomerAddressType<TProperty>(
            FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
            Expression<Func<TInputBase, TProperty>> propertyExpression,
            Func<TInputBase, CustomerAddressType> getCustomerAddressTypeFunction
        )
        {
            fluentValidationValidatorWrapper.RuleFor(propertyExpression)
                .Must((input, customerAddressType) => CustomerAddressSpecifications.CustomerAddressShouldHaveCustomerAddressType(getCustomerAddressTypeFunction(input)))
                .WithErrorCode(ICustomerAddressSpecifications.CustomerAddressShouldHaveCustomerAddressTypeErrorCode)
                .WithMessage(ICustomerAddressSpecifications.CustomerAddressShouldHaveCustomerAddressTypeMessage)
                .WithSeverity(ICustomerAddressSpecifications.CustomerAddressShouldHaveCustomerAddressTypeSeverity);
        }
        protected void AddCustomerAddressShouldHaveAddressValueObject<TProperty>(
            FluentValidationValidatorWrapper fluentValidationValidatorWrapper,
            Expression<Func<TInputBase, TProperty>> propertyExpression,
            Func<TInputBase, AddressValueObject> getAddressValueObjectFunction
        )
        {
            fluentValidationValidatorWrapper.RuleFor(propertyExpression)
                .Must((input, customerAddressType) => CustomerAddressSpecifications.CustomerAddressShouldHaveAddressValueObject(getAddressValueObjectFunction(input)))
                .WithErrorCode(ICustomerAddressSpecifications.CustomerAddressShouldHaveCustomerAddressTypeErrorCode)
                .WithMessage(ICustomerAddressSpecifications.CustomerAddressShouldHaveCustomerAddressTypeMessage)
                .WithSeverity(ICustomerAddressSpecifications.CustomerAddressShouldHaveCustomerAddressTypeSeverity);
        }
    }
}
