using MCB.Core.Domain.Entities.DomainEntitiesBase.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Specifications.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Specifications
{
    public class CustomerAddressInfoSpecifications
        : DomainEntitySpecifications,
        ICustomerAddressInfoSpecifications
    {
        public bool CustomerAddressInfoShouldHaveDefaultShippingAddress(CustomerAddress defaultShippingAddress)
        {
            return defaultShippingAddress != null;
        }
        public bool CustomerAddressInfoShouldHaveCustomerAddressCollection(IEnumerable<CustomerAddress> customerAddressCollection)
        {
            return customerAddressCollection?.Any() == true;
        }
        public bool CustomerAddressInfoShouldHaveDefaultShippingAddressInCustomerAddressCollection(CustomerAddress defaultShippingAddress, IEnumerable<CustomerAddress> customerAddressCollection)
        {
            return customerAddressCollection?.Any(q => q == defaultShippingAddress) == true;
        }
    }
}
