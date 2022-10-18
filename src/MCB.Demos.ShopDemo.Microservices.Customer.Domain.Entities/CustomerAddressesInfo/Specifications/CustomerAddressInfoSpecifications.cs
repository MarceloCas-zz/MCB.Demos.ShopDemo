using MCB.Core.Domain.Entities.DomainEntitiesBase.Specifications;
using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Specifications.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Specifications;

public sealed class CustomerAddressInfoSpecifications
    : DomainEntitySpecifications,
    ICustomerAddressInfoSpecifications
{
    // Constructors
    public CustomerAddressInfoSpecifications(
        IDateTimeProvider dateTimeProvider
    ) : base(dateTimeProvider)
    {
    }

    // Public Methods
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
    public bool CustomerAddressInfoShouldHaveCustomerAddressInCustomerAddressCollection(Guid customerAddressId, IEnumerable<CustomerAddress> customerAddressCollection)
    {
        return customerAddressCollection?.Any(q => q.Id == customerAddressId) == true;
    }
}