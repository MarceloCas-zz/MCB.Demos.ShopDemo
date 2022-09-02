using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories
{
    public class CustomerAddressInfoFactory
        : ICustomerAddressInfoFactory
    {
        // Fields
        private readonly ICustomerAddressFactory _customerAddressFactory;
        private readonly IRegisterNewCustomerAddressInputFactory _registerNewCustomerAddressInputFactory;
        private readonly IRegisterNewCustomerAddressInfoInputShouldBeValidValidator _registerNewCustomerAddressInfoValidator;
        private readonly IChangeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator _changeDefaultCustomerAddressInfoShippingAddressValidator;
        private readonly ICustomerAddressShouldBeValidValidator _customerAddressIsValidValidator;
        private readonly IClearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator _clearDefaultCustomerAddressInfoShippingAddressInputValidator;
        private readonly IAddNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator _addNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator;

        // Constructors
        public CustomerAddressInfoFactory(
            ICustomerAddressFactory customerAddressFactory,
            IRegisterNewCustomerAddressInputFactory registerNewCustomerAddressInputFactory,
            IRegisterNewCustomerAddressInfoInputShouldBeValidValidator registerNewCustomerAddressInfoValidator,
            IChangeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator changeDefaultCustomerAddressInfoShippingAddressValidator,
            ICustomerAddressShouldBeValidValidator customerAddressIsValidValidator,
            IClearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator clearDefaultCustomerAddressInfoShippingAddressInputValidator,
            IAddNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator addNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator
        )
        {
            _customerAddressFactory = customerAddressFactory;
            _registerNewCustomerAddressInputFactory = registerNewCustomerAddressInputFactory;
            _registerNewCustomerAddressInfoValidator = registerNewCustomerAddressInfoValidator;
            _changeDefaultCustomerAddressInfoShippingAddressValidator = changeDefaultCustomerAddressInfoShippingAddressValidator;
            _customerAddressIsValidValidator = customerAddressIsValidValidator;
            _clearDefaultCustomerAddressInfoShippingAddressInputValidator = clearDefaultCustomerAddressInfoShippingAddressInputValidator;
            _addNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator = addNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator;
        }

        // Public Methods
        public CustomerAddressInfo Create()
        {
            return new CustomerAddressInfo(
                _customerAddressFactory,
                _registerNewCustomerAddressInputFactory,
                _registerNewCustomerAddressInfoValidator,
                _changeDefaultCustomerAddressInfoShippingAddressValidator,
                _customerAddressIsValidValidator,
                _clearDefaultCustomerAddressInfoShippingAddressInputValidator,
                _addNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator
            );
        }
    }
}
