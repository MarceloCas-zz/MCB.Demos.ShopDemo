using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators
{
    public class ChangeCustomerNameInputShouldBeValidValidator
        : CustomerInputValidatorBase<ChangeCustomerNameInput>,
        IChangeCustomerNameInputShouldBeValidValidator
    {
        // Constructors
        public ChangeCustomerNameInputShouldBeValidValidator(
            ICustomerSpecifications customerSpecifications
        ) : base(customerSpecifications)
        {
        }

        // Configure
        protected override void ConfigureFluentValidationConcreteValidatorInternal(ValidatorBase<ChangeCustomerNameInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
        {
            // FirstName
            AddCustomerShouldHaveFirstName(
                fluentValidationValidatorWrapper,
                propertyExpression: input => input.FirstName,
                getFirstNameFunction: input => input.FirstName
            );
            AddCustomerShouldHaveFirstNameMaximumLength(
                fluentValidationValidatorWrapper,
                propertyExpression: input => input.FirstName,
                getFirstNameFunction: input => input.FirstName
            );

            // LastName
            AddCustomerShouldHaveLastName(
                fluentValidationValidatorWrapper,
                propertyExpression: input => input.LastName,
                getLastNameFunction: input => input.LastName
            );
            AddCustomerShouldHaveLastNameMaximumLength(
                fluentValidationValidatorWrapper,
                propertyExpression: input => input.LastName,
                getLastNameFunction: input => input.LastName
            );
        }
    }
}
