using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories
{
    public class CustomerAddressInfoFactory
        : ICustomerAddressInfoFactory
    {
        // Fields
        private readonly IRegisterNewCustomerAddressInfoValidator _registerNewCustomerAddressInfoValidator;

        // Constructors
        public CustomerAddressInfoFactory(
            IRegisterNewCustomerAddressInfoValidator registerNewCustomerAddressInfoValidator
        )
        {
            _registerNewCustomerAddressInfoValidator = registerNewCustomerAddressInfoValidator;
        }

        // Public Methods
        public CustomerAddressInfo Create()
        {
            return new CustomerAddressInfo(
                _registerNewCustomerAddressInfoValidator
            );
        }
    }
}
