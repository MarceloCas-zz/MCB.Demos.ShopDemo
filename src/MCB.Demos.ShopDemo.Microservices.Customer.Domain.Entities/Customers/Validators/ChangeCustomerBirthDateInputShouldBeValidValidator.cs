using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators
{
    public class ChangeCustomerBirthDateInputShouldBeValidValidator
        : CustomerInputValidatorBase<ChangeCustomerBirthDateInput>,
        IChangeCustomerBirthDateInputShouldBeValidValidator
    {
        // Constructors
        public ChangeCustomerBirthDateInputShouldBeValidValidator(
            ICustomerSpecifications customerSpecifications
        ) : base(customerSpecifications)
        {
        }

        // Configure
        protected override void ConfigureFluentValidationConcreteValidatorInternal(ValidatorBase<ChangeCustomerBirthDateInput>.FluentValidationValidatorWrapper fluentValidationValidatorWrapper)
        {
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
