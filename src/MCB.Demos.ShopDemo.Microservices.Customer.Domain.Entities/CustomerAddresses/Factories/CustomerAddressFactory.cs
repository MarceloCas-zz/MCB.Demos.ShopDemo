using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Factories
{
    public class CustomerAddressFactory
        : ICustomerAddressFactory
    {
        // Fields
        private readonly IChangeCustomerAddressTypeInputShouldBeValidValidator _changeCustomerAddressTypeValidator;
        private readonly IChangeCustomerAddressInputShouldBeValidValidator _changeCustomerAddressValidator;
        private readonly IChangeCustomerFullAddressInfoInputShouldBeValidValidator _changeCustomerFullAddressInfoValidator;
        private readonly IRegisterNewCustomerAddressInputShouldBeValidValidator _registerNewCustomerAddressValidator;

        // Constructors
        public CustomerAddressFactory(
            IChangeCustomerAddressTypeInputShouldBeValidValidator changeCustomerAddressTypeValidator,
            IChangeCustomerAddressInputShouldBeValidValidator changeCustomerAddressValidator,
            IChangeCustomerFullAddressInfoInputShouldBeValidValidator changeCustomerFullAddressInfoValidator,
            IRegisterNewCustomerAddressInputShouldBeValidValidator registerNewCustomerAddressValidator
        )
        {
            _changeCustomerAddressTypeValidator = changeCustomerAddressTypeValidator;
            _changeCustomerAddressValidator = changeCustomerAddressValidator;
            _changeCustomerFullAddressInfoValidator = changeCustomerFullAddressInfoValidator;
            _registerNewCustomerAddressValidator = registerNewCustomerAddressValidator;
        }

        // Public Methods
        public CustomerAddress Create()
        {
            return new CustomerAddress(
                _changeCustomerAddressTypeValidator,
                _changeCustomerAddressValidator,
                _changeCustomerFullAddressInfoValidator,
                _registerNewCustomerAddressValidator
            );
        }
    }
}
