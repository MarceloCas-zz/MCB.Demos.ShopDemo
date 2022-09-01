using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories
{
    public class CustomerAddressInfoFactory
        : ICustomerAddressInfoFactory
    {
        // Fields
        private readonly ICustomerAddressFactory _customerAddressFactory;
        private readonly IRegisterNewCustomerAddressInputFactory _registerNewCustomerAddressInputFactory;
        private readonly IRegisterNewCustomerAddressInfoValidator _registerNewCustomerAddressInfoValidator;
        private readonly IChangeDefaultCustomerAddressInfoShippingAddressValidator _changeDefaultCustomerAddressInfoShippingAddressValidator;
        private readonly ICustomerAddressIsValidValidator _customerAddressIsValidValidator;

        // Constructors
        public CustomerAddressInfoFactory(
            ICustomerAddressFactory customerAddressFactory,
            IRegisterNewCustomerAddressInputFactory registerNewCustomerAddressInputFactory,
            IRegisterNewCustomerAddressInfoValidator registerNewCustomerAddressInfoValidator,
            IChangeDefaultCustomerAddressInfoShippingAddressValidator changeDefaultCustomerAddressInfoShippingAddressValidator,
            ICustomerAddressIsValidValidator customerAddressIsValidValidator
        )
        {
            _customerAddressFactory = customerAddressFactory;
            _registerNewCustomerAddressInputFactory = registerNewCustomerAddressInputFactory;
            _registerNewCustomerAddressInfoValidator = registerNewCustomerAddressInfoValidator;
            _changeDefaultCustomerAddressInfoShippingAddressValidator = changeDefaultCustomerAddressInfoShippingAddressValidator;
            _customerAddressIsValidValidator = customerAddressIsValidValidator;
        }

        // Public Methods
        public CustomerAddressInfo Create()
        {
            return new CustomerAddressInfo(
                _customerAddressFactory,
                _registerNewCustomerAddressInputFactory,
                _registerNewCustomerAddressInfoValidator,
                _changeDefaultCustomerAddressInfoShippingAddressValidator,
                _customerAddressIsValidValidator
            );
        }
    }
}
