using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Wrappers;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators
{
    public class ChangeCustomerNameInputShouldBeValidValidator
        : ValidatorBase<ChangeCustomerNameInput>,
        IChangeCustomerNameInputShouldBeValidValidator
    {
        // Fields
        private readonly ICustomerSpecifications _customerSpecifications;

        // Constructors
        public ChangeCustomerNameInputShouldBeValidValidator(
            ICustomerSpecifications customerSpecifications
        )
        {
            _customerSpecifications = customerSpecifications;
        }

        // Protected Methods
        protected override void ConfigureFluentValidationConcreteValidator(FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
        {
            // FirstName
            CustomerValidatorWrapper.AddCustomerShouldHaveFirstName(
                _customerSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: input => input.FirstName,
                getFirstNameFunction: input => input.FirstName
            );
            CustomerValidatorWrapper.AddCustomerShouldHaveFirstNameMaximumLength(
                _customerSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: input => input.FirstName,
                getFirstNameFunction: input => input.FirstName
            );

            // LastName
            CustomerValidatorWrapper.AddCustomerShouldHaveLastName(
                _customerSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: input => input.LastName,
                getLastNameFunction: input => input.LastName
            );
            CustomerValidatorWrapper.AddCustomerShouldHaveLastNameMaximumLength(
                _customerSpecifications,
                fluentValidationValidatorWrapper,
                propertyExpression: input => input.LastName,
                getLastNameFunction: input => input.LastName
            );
        }
    }
}
