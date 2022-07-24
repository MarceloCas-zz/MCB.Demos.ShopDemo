using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Base;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators
{
    public class RegisterNewCustomerInputShouldBeValidValidator
        : CustomerInputValidatorBase<RegisterNewCustomerInput>,
        IRegisterNewCustomerInputShouldBeValidValidator
    {
        // Fields

        // Constructors
        public RegisterNewCustomerInputShouldBeValidValidator(
            ICustomerSpecifications customerSpecifications
        ) : base(customerSpecifications)
        {
        }

        // Configure
        protected override void ConfigureFluentValidationConcreteValidatorInternal(FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
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

            // BirthDate
            AddCustomerShouldHaveBirthDate(
                fluentValidationValidatorWrapper,
                propertyExpression: input => input.BirthDate,
                getBirthDateFunction: input => input.BirthDate
            );
            AddCustomerShouldHaveValidBirthDate(
                fluentValidationValidatorWrapper,
                propertyExpression: input => input.BirthDate,
                getBirthDateFunction: input => input.BirthDate
            );
        }
    }
}
