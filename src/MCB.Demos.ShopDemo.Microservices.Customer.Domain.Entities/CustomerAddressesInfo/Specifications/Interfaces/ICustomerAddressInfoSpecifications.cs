using FluentValidation;
using MCB.Core.Domain.Entities.Abstractions.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Specifications.Interfaces;

public interface ICustomerAddressInfoSpecifications
    : IDomainEntitySpecifications
{
    // CustomerAddressCollection
    public static readonly string CustomerAddressInfoShouldHaveCustomerAddressCollectionErrorCode = nameof(CustomerAddressInfoShouldHaveCustomerAddressCollectionErrorCode);
    public static readonly string CustomerAddressInfoShouldHaveCustomerAddressCollectionMessage = nameof(CustomerAddressInfoShouldHaveCustomerAddressCollectionMessage);
    public static readonly Severity CustomerAddressInfoShouldHaveCustomerAddressCollectionSeverity = Severity.Error;

    // DefaultShippingAddress
    public static readonly string CustomerAddressInfoShouldHaveDefaultShippingAddressErrorCode = nameof(CustomerAddressInfoShouldHaveDefaultShippingAddressErrorCode);
    public static readonly string CustomerAddressInfoShouldHaveDefaultShippingAddressMessage = nameof(CustomerAddressInfoShouldHaveDefaultShippingAddressMessage);
    public static readonly Severity CustomerAddressInfoShouldHaveDefaultShippingAddressSeverity = Severity.Error;

    // Others
    public static readonly string CustomerAddressInfoShouldHaveDefaultShippingAddressInCustomerAddressCollectionErrorCode = nameof(CustomerAddressInfoShouldHaveDefaultShippingAddressInCustomerAddressCollectionErrorCode);
    public static readonly string CustomerAddressInfoShouldHaveDefaultShippingAddressInCustomerAddressCollectionMessage = nameof(CustomerAddressInfoShouldHaveDefaultShippingAddressInCustomerAddressCollectionMessage);
    public static readonly Severity CustomerAddressInfoShouldHaveDefaultShippingAddressInCustomerAddressCollectionSeverity = Severity.Error;

    public static readonly string CustomerAddressInfoShouldHaveCustomerAddressInCustomerAddressCollectionErrorCode = nameof(CustomerAddressInfoShouldHaveCustomerAddressInCustomerAddressCollectionErrorCode);
    public static readonly string CustomerAddressInfoShouldHaveCustomerAddressInCustomerAddressCollectionMessage = nameof(CustomerAddressInfoShouldHaveCustomerAddressInCustomerAddressCollectionMessage);
    public static readonly Severity CustomerAddressInfoShouldHaveCustomerAddressInCustomerAddressCollectionSeverity = Severity.Error;

    // Methods
    bool CustomerAddressInfoShouldHaveCustomerAddressCollection(IEnumerable<CustomerAddress> customerAddressCollection);
    bool CustomerAddressInfoShouldHaveDefaultShippingAddress(CustomerAddress defaultShippingAddress);
    bool CustomerAddressInfoShouldHaveDefaultShippingAddressInCustomerAddressCollection(CustomerAddress defaultShippingAddress, IEnumerable<CustomerAddress> customerAddressCollection);
    bool CustomerAddressInfoShouldHaveCustomerAddressInCustomerAddressCollection(Guid customerAddressId, IEnumerable<CustomerAddress> customerAddressCollection);
}