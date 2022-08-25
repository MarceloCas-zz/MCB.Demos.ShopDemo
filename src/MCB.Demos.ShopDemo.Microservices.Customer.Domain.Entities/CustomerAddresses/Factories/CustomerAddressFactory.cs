using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Factories
{
    public class CustomerAddressFactory
        : ICustomerAddressFactory
    {
        // Fields
        private readonly IChangeCustomerAddressTypeValidator _changeCustomerAddressTypeValidator;
        private readonly IChangeCustomerAddressValidator _changeCustomerAddressValidator;
        private readonly IChangeCustomerFullAddressInfoValidator _changeCustomerFullAddressInfoValidator;
        private readonly IRegisterNewCustomerAddressValidator _registerNewCustomerAddressValidator;

        // Constructors
        public CustomerAddressFactory(
            IChangeCustomerAddressTypeValidator changeCustomerAddressTypeValidator,
            IChangeCustomerAddressValidator changeCustomerAddressValidator,
            IChangeCustomerFullAddressInfoValidator changeCustomerFullAddressInfoValidator,
            IRegisterNewCustomerAddressValidator registerNewCustomerAddressValidator
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
