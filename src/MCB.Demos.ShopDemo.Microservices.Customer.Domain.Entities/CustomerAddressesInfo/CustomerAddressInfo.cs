using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo
{
    public class CustomerAddressInfo
        : DomainEntityBase
    {
        // Fields
        private readonly List<CustomerAddress> _customerAddressCollection = new();
        private CustomerAddress _defaultShippingAddress;

        // Properties
        public IEnumerable<CustomerAddress> CustomerAddressCollection => _customerAddressCollection.Select(q => q.DeepClone());
        public CustomerAddress DefaultShippingAddress => _defaultShippingAddress?.DeepClone();

        // Factories
        private readonly ICustomerAddressFactory _customerAddressFactory;
        private readonly IRegisterNewCustomerAddressInputFactory _registerNewCustomerAddressInputFactory;

        // Validators
        private readonly IRegisterNewCustomerAddressInfoInputShouldBeValidValidator _registerNewCustomerAddressInfoInputShouldBeValidValidator;
        private readonly IChangeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator _changeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator;
        private readonly ICustomerAddressShouldBeValidValidator _customerAddressShouldBeValidValidator;
        private readonly IClearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator _clearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator;

        // Constructors
        public CustomerAddressInfo(
            ICustomerAddressFactory customerAddressFactory,
            IRegisterNewCustomerAddressInputFactory registerNewCustomerAddressInputShouldBeValidFactory,
            IRegisterNewCustomerAddressInfoInputShouldBeValidValidator registerNewCustomerAddressInfoInputShouldBeValidValidator,
            IChangeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator changeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator,
            ICustomerAddressShouldBeValidValidator customerAddressShouldBeValidValidator,
            IClearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator clearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator
        )
        {
            _customerAddressFactory = customerAddressFactory;
            _registerNewCustomerAddressInputFactory = registerNewCustomerAddressInputShouldBeValidFactory;
            _registerNewCustomerAddressInfoInputShouldBeValidValidator = registerNewCustomerAddressInfoInputShouldBeValidValidator;
            _changeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator = changeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator;
            _customerAddressShouldBeValidValidator = customerAddressShouldBeValidValidator;
            _clearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator = clearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator;
        }

        // Public Methods
        public CustomerAddressInfo RegisterNewCustomerAddressInfo(RegisterNewCustomerAddressInfoInput input)
        {
            // Validate input
            if (!Validate(() => _registerNewCustomerAddressInfoInputShouldBeValidValidator.Validate(input)))
                return this;

            // Register new customer address
            var customerAddress = 
                _customerAddressFactory
                .Create()
                .RegisterNewCustomerAddress(_registerNewCustomerAddressInputFactory.Create(input));

            if (!Validate(() => customerAddress.ValidationInfo))
                return this;

            // Process
            AddCustomerAddress(customerAddress);

            if (ValidationInfo.IsValid)
                return this;

            // Return
            return RegisterNewInternal<CustomerAddressInfo>(input.TenantId, input.ExecutionUser, input.SourcePlatform);
        }
        public CustomerAddress ChangeDefaultCustomerAddressInfoShippingAddress(ChangeDefaultCustomerAddressInfoShippingAddressInput input)
        {
            // Validate input
            if (!Validate(() => _changeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator.Validate(input)))
                return null;

            // Validate customer address in input
            if (!Validate(() => _customerAddressShouldBeValidValidator.Validate(input.CustomerAddress)))
                return null;

            // Process
            SetDefaultShippingAddress(input.CustomerAddress)
                .RegisterModificationInternal<CustomerAddressInfo>(input.ExecutionUser, input.SourcePlatform);

            return DefaultShippingAddress;
        }
        public CustomerAddressInfo ClearDefaultCustomerAddressInfoShippingAddress(ClearDefaultCustomerAddressInfoShippingAddressInput input)
        {
            // Validate
            if (!Validate(() => _clearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator.Validate(input)))
                return this;

            // Process and Return
            return SetDefaultShippingAddress(null)
                .RegisterModificationInternal<CustomerAddressInfo>(input.ExecutionUser, input.SourcePlatform);
        }

        public CustomerAddress AddNewCustomerAddressInfoCustomerAddress(AddNewCustomerAddressInfoCustomerAddressInput input)
        {
            // Process customer address
            var customerAddress = new CustomerAddress(
                    new ChangeCustomerAddressTypeInputShouldBeValidValidator(new CustomerAddressSpecifications()),
                    new ChangeCustomerAddressInputShouldBeValidValidator(new CustomerAddressSpecifications()),
                    new ChangeCustomerFullAddressInfoInputShouldBeValidValidator(new CustomerAddressSpecifications()),
                    new RegisterNewCustomerAddressInputShouldBeValidValidator(new CustomerAddressSpecifications())
                )
                .RegisterNewCustomerAddress(new CustomerAddresses.Inputs.RegisterNewCustomerAddressInput(
                    input.TenantId, 
                    input.CustomerAddressType, 
                    input.AddressValueObject, 
                    input.ExecutionUser, 
                    input.SourcePlatform
                ));
            AddFromValidationInfoInternal(customerAddress.ValidationInfo);

            // Validate customer address after registration
            if (!ValidationInfo.IsValid)
                return null;

            // Process
            _customerAddressCollection.Add(
                customerAddress
            );
            RegisterModificationInternal<CustomerAddressInfo>(input.ExecutionUser, input.SourcePlatform);

            // Return
            return customerAddress;
        }
        public CustomerAddress RemoveCustomerAddressInfoCustomerAddress(RemoveCustomerAddressInfoCustomerAddressInput input)
        {
            // Validate
            // TODO: Add validation

            // Process
            var customerAddress = _customerAddressCollection.FirstOrDefault(q => q.Id == input.CustomerAddressId);
            if (customerAddress is null)
                return null;

            _customerAddressCollection.Remove(
                customerAddress
            );
            RegisterModificationInternal<CustomerAddressInfo>(input.ExecutionUser, input.SourcePlatform);

            // Return
            return customerAddress;
        }
        public CustomerAddress ChangeCustomerAddressInfoCustomerAddress(ChangeCustomerAddressInfoCustomerAddressInput input)
        {
            var customerAddress = _customerAddressCollection.FirstOrDefault(q => q.Id == input.CustomerAddressId);

            // Validate
            // TODO: Add validation
            if (customerAddress == null)
                return null;

            // Process
            customerAddress.ChangeCustomerFullAddressInfo(new CustomerAddresses.Inputs.ChangeCustomerFullAddressInfoInput(
                input.TenantId,
                input.CustomerAddressType, 
                input.AddressValueObject, 
                input.ExecutionUser,
                input.SourcePlatform
            ));
            RegisterModificationInternal<CustomerAddressInfo>(input.ExecutionUser, input.SourcePlatform);

            // Return
            return customerAddress;
        }

        public CustomerAddressInfo DeepClone()
        {
            // Process
            var customerAddressInfo = DeepCloneInternal<CustomerAddressInfo>()
                .SetCustomerAddressCollection(_customerAddressCollection);

            if (_defaultShippingAddress != null)
                customerAddressInfo.SetDefaultShippingAddress(_defaultShippingAddress);

            // Return
            return customerAddressInfo;
        }

        // Private Methods
        private CustomerAddressInfo AddCustomerAddress(CustomerAddress customerAddress)
        {
            _customerAddressCollection.Add(customerAddress);
            return this;
        }
        private CustomerAddressInfo SetCustomerAddressCollection(IEnumerable<CustomerAddress> customerAddressCollection)
        {
            // Validate
            // TODO: Add validation

            // Process
            _customerAddressCollection.Clear();
            _customerAddressCollection.AddRange(customerAddressCollection);

            // Return
            return this;
        }
        private CustomerAddressInfo SetDefaultShippingAddress(CustomerAddress customerAddress)
        {
            _defaultShippingAddress = customerAddress;
            return this;
        }

        // Protected Abstract Methods
        protected override DomainEntityBase CreateInstanceForCloneInternal() => new CustomerAddressInfo(
            _customerAddressFactory,
            _registerNewCustomerAddressInputFactory,
            _registerNewCustomerAddressInfoInputShouldBeValidValidator,
            _changeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator,
            _customerAddressShouldBeValidValidator,
            _clearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator
        );
    }
}
