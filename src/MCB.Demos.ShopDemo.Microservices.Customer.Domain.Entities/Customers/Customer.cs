using MCB.Core.Domain.Entities.Abstractions;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers
{
    public class Customer
        : DomainEntityBase,
        IAggregationRoot
    {
        // Fields
        private CustomerAddressInfo _customerAddressInfo = new();

        // Properties
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateOnly BirthDate { get; private set; }

        // Navigation Properties
        public CustomerAddressInfo CustomerAddressInfo => _customerAddressInfo.DeepClone();

        // Validators
        private readonly IRegisterNewCustomerInputShouldBeValidValidator _customerRegisterNewInputShouldBeValidValidator;

        // Constructors
        public Customer(
            IRegisterNewCustomerInputShouldBeValidValidator customerRegisterNewInputShouldBeValidValidator
        )
        {
            FirstName = string.Empty;
            LastName = string.Empty;

            _customerRegisterNewInputShouldBeValidValidator = customerRegisterNewInputShouldBeValidValidator;
        }

        // Public Methods
        public Customer RegisterNewCustomer(RegisterNewCustomerInput input)
        {
            // Validate
            if (!Validate<Customer>(() => _customerRegisterNewInputShouldBeValidValidator.Validate(input)))
                return this;

            // Process and Return
            return SetName(input.FirstName, input.LastName)
                .SetBirthDate(input.BirthDate)
                .RegisterNewInternal<Customer>(input.TenantId, input.ExecutionUser, input.SourcePlatform);
        }
        public Customer ChangeCustomerName(ChangeCustomerNameInput input)
        {
            // Validate
            // TODO: Add validation

            // Process and Return
            return SetName(input.FirstName, input.LastName)
                .RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);
        }
        public Customer ChangeBirthDate(ChangeBirthDateInput input)
        {
            // Validate
            // TODO: Add validation

            // Process and Return
            return SetBirthDate(input.BirthDate)
                .RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);
        }

        public CustomerAddress ChangeDefaultShippingAddress(ChangeDefaultShippingAddressInput input)
        {
            // Validate
            // TODO: Add validation

            // Process
            var newDefaultShippingAddress = _customerAddressInfo.ChangeDefaultShippingAddress(input.CustomerAddress, input.ExecutionUser, input.SourcePlatform);
            RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);

            // Return
            return newDefaultShippingAddress;
        }
        public Customer ClearDefaultShippingAddress(ClearDefaultShippingAddressInput input)
        {
            // Validate
            // TODO: Add validation

            // Process
            _customerAddressInfo.ClearDefaultShippingAddress(input.ExecutionUser, input.SourcePlatform);
            RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);

            // Return
            return this;
        }

        public CustomerAddress AddNewCustomerAddress(AddNewCustomerAddressInput input)
        {
            // Validate
            // TODO: Add validation

            // Process
            var addedCustomerAddress = _customerAddressInfo.AddNewCustomerAddress(
                input.CustomerAddressType, 
                input.AddressValueObject, 
                input.ExecutionUser, 
                input.SourcePlatform
            );
            RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);

            // Return
            return addedCustomerAddress;
        }
        public CustomerAddress RemoveCustomerAddress(RemoveCustomerAddressInput input)
        {
            // Validate
            // TODO: Add validation

            // Process
            var removedCustomerAddress = _customerAddressInfo.RemoveCustomerAddress(input.CustomerAddressId, input.ExecutionUser, input.SourcePlatform);
            RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);

            // Return
            return removedCustomerAddress;
        }
        public CustomerAddress ChangeCustomerAddress(ChangeCustomerAddressInput input)
        {
            var customerAddress = _customerAddressInfo.CustomerAddressCollection.FirstOrDefault(q => q.Id == input.CustomerAddressId);

            // Validate
            // TODO: Add validation
            if (customerAddress == null)
                return null;

            // Process
            var changedCustomerAddress = _customerAddressInfo.ChangeCustomerAddress(
                input.CustomerAddressId, 
                input.CustomerAddressType, 
                input.AddressValueObject, 
                input.ExecutionUser,
                input.SourcePlatform
            );
            RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);

            // Return
            return changedCustomerAddress;
        }

        public Customer DeepClone()
        {
            // Process and Return
            return DeepCloneInternal<Customer>()
                .SetName(FirstName, LastName)
                .SetBirthDate(BirthDate)
                .SetCustomerAddressInfo(CustomerAddressInfo);
        }

        // Protected Abstract Methods
        protected override DomainEntityBase CreateInstanceForCloneInternal() =>
            new Customer(_customerRegisterNewInputShouldBeValidValidator);

        // Private Methods
        private Customer SetName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            return this;
        }
        private Customer SetBirthDate(DateOnly birthDate)
        {
            BirthDate = birthDate;

            return this;
        }
        private Customer SetCustomerAddressInfo(CustomerAddressInfo customerAddressInfo)
        {
            _customerAddressInfo = customerAddressInfo;
            return this;
        }
    }
}
