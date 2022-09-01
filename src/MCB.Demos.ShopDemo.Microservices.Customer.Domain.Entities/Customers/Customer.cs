using MCB.Core.Domain.Entities.Abstractions;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers
{
    public class Customer
        : DomainEntityBase,
        IAggregationRoot
    {
        // Fields
        private CustomerAddressInfo _customerAddressInfo;

        // Properties
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateOnly BirthDate { get; private set; }

        // Navigation Properties
        public CustomerAddressInfo CustomerAddressInfo => _customerAddressInfo.DeepClone();

        // Validators
        private readonly IRegisterNewCustomerInputShouldBeValidValidator _customerCustomerRegisterNewInputShouldBeValidValidator;
        private readonly IChangeCustomerNameInputShouldBeValidValidator _changeCustomerNameInputShouldBeValidValidator;
        private readonly IChangeCustomerBirthDateInputShouldBeValidValidator _changeCustomerBirthDateInputShouldBeValidValidator;
        private readonly IAddNewCustomerAddressInputShouldBeValidValidator _addNewCustomerAddressInputShouldBeValidValidator;

        // Constructors
        public Customer(
            IRegisterNewCustomerInputShouldBeValidValidator customerRegisterNewInputShouldBeValidValidator,
            IChangeCustomerNameInputShouldBeValidValidator changeCustomerNameInputShouldBeValidValidator,
            IChangeCustomerBirthDateInputShouldBeValidValidator changeCustomerBirthDateInputShouldBeValidValidator,
            IAddNewCustomerAddressInputShouldBeValidValidator addNewCustomerAddressInputShouldBeValidValidator
        )
        {
            FirstName = string.Empty;
            LastName = string.Empty;

            _customerCustomerRegisterNewInputShouldBeValidValidator = customerRegisterNewInputShouldBeValidValidator;
            _changeCustomerNameInputShouldBeValidValidator = changeCustomerNameInputShouldBeValidValidator;
            _changeCustomerBirthDateInputShouldBeValidValidator = changeCustomerBirthDateInputShouldBeValidValidator;
            _addNewCustomerAddressInputShouldBeValidValidator = addNewCustomerAddressInputShouldBeValidValidator;

            _customerAddressInfo = new CustomerAddressInfo(
                customerAddressFactory: null,
                registerNewCustomerAddressInputFactory: null,
                new RegisterNewCustomerAddressInfoValidator(new CustomerAddressSpecifications()),
                new ChangeDefaultCustomerAddressInfoShippingAddressValidator(new CustomerAddressSpecifications()),
                new CustomerAddressIsValidValidator(new CustomerAddressSpecifications()),
                new ClearDefaultCustomerAddressInfoShippingAddressInputValidator()
            );
        }

        // Public Methods
        public Customer RegisterNewCustomer(RegisterNewCustomerInput input)
        {
            // Validate
            if (!Validate(() => _customerCustomerRegisterNewInputShouldBeValidValidator.Validate(input)))
                return this;

            // Process and Return
            return SetName(input.FirstName, input.LastName)
                .SetBirthDate(input.BirthDate)
                .RegisterNewInternal<Customer>(input.TenantId, input.ExecutionUser, input.SourcePlatform);
        }
        public Customer ChangeCustomerName(ChangeCustomerNameInput input)
        {
            // Validate
            if (!Validate(() => _changeCustomerNameInputShouldBeValidValidator.Validate(input)))
                return this;
            
            // Process and Return
            return SetName(input.FirstName, input.LastName)
                .RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);
        }
        public Customer ChangeBirthDate(ChangeCustomerBirthDateInput input)
        {
            // Validate
            if (!Validate(() => _changeCustomerBirthDateInputShouldBeValidValidator.Validate(input)))
                return this;

            // Process and Return
            return SetBirthDate(input.BirthDate)
                .RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);
        }

        public CustomerAddress ChangeDefaultShippingAddress(ChangeCustomerDefaultShippingAddressInput input)
        {
            // Validate
            // TODO: Add validation

            // Process
            var newDefaultShippingAddress = _customerAddressInfo.ChangeDefaultCustomerAddressInfoShippingAddress(new CustomerAddressesInfo.Inputs.ChangeDefaultCustomerAddressInfoShippingAddressInput(
                TenantId,
                input.CustomerAddress, 
                input.ExecutionUser, 
                input.SourcePlatform
            ));
            RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);

            // Return
            return newDefaultShippingAddress;
        }
        public Customer ClearDefaultShippingAddress(ClearCustomerDefaultShippingAddressInput input)
        {
            // Validate
            // TODO: Add validation

            // Process
            _customerAddressInfo.ClearDefaultCustomerAddressInfoShippingAddress(new CustomerAddressesInfo.Inputs.ClearDefaultCustomerAddressInfoShippingAddressInput(
                TenantId,
                input.ExecutionUser, 
                input.SourcePlatform
            ));
            RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);

            // Return
            return this;
        }

        public CustomerAddress AddNewCustomerAddress(AddNewCustomerAddressInput input)
        {
            // Process Customer Address
            var addedCustomerAddress = _customerAddressInfo.AddNewCustomerAddressInfoCustomerAddress(new CustomerAddressesInfo.Inputs.AddNewCustomerAddressInfoCustomerAddressInput(
                TenantId,
                input.CustomerAddressType,
                input.AddressValueObject,
                input.ExecutionUser,
                input.SourcePlatform
            ));

            // Validate After Customer Address Process
            if (!addedCustomerAddress.ValidationInfo.IsValid)
            {
                AddFromValidationInfoInternal(addedCustomerAddress.ValidationInfo);
                return null;
            }

            // Process Customer
            RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);

            // Return
            return addedCustomerAddress;
        }
        public CustomerAddress RemoveCustomerAddress(RemoveCustomerAddressInput input)
        {
            // Validate
            // TODO: Add validation

            // Process
            var removedCustomerAddress = _customerAddressInfo.RemoveCustomerAddressInfoCustomerAddress(new CustomerAddressesInfo.Inputs.RemoveCustomerAddressInfoCustomerAddressInput(
                TenantId,
                input.CustomerAddressId, 
                input.ExecutionUser, 
                input.SourcePlatform
            ));
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
            var changedCustomerAddress = _customerAddressInfo.ChangeCustomerAddressInfoCustomerAddress(new CustomerAddressesInfo.Inputs.ChangeCustomerAddressInfoCustomerAddressInput(
                TenantId,
                input.CustomerAddressId,
                input.CustomerAddressType,
                input.AddressValueObject,
                input.ExecutionUser,
                input.SourcePlatform
            ));
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
            new Customer(
                _customerCustomerRegisterNewInputShouldBeValidValidator,
                _changeCustomerNameInputShouldBeValidValidator,
                _changeCustomerBirthDateInputShouldBeValidValidator,
                _addNewCustomerAddressInputShouldBeValidValidator
            );

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
