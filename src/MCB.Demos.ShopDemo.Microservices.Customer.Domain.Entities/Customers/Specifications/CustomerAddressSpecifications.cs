using MCB.Core.Domain.Entities.DomainEntitiesBase.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications
{
    public class CustomerAddressSpecifications
        : DomainEntitySpecifications,
        ICustomerAddressSpecifications
    {
        // Public Methods
        public bool CustomerAddressShouldHaveCustomerAddressType(CustomerAddressType customerAddressType)
        {
            return Enum.IsDefined(typeof(CustomerAddressType), customerAddressType);
        }
        public bool CustomerAddressShouldHaveAddressValueObject(AddressValueObject addressValueObject)
        {
            return !addressValueObject.Equals(new AddressValueObject());
        }
    }
}
