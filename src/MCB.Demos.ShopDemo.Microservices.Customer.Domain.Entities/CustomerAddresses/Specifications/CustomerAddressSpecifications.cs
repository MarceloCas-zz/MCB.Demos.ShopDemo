using MCB.Core.Domain.Entities.DomainEntitiesBase.Specifications;
using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications;

public sealed class CustomerAddressSpecifications
    : DomainEntitySpecifications,
    ICustomerAddressSpecifications
{
    // Constructors
    public CustomerAddressSpecifications(
        IDateTimeProvider dateTimeProvider
    ) : base(dateTimeProvider)
    {
    }

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