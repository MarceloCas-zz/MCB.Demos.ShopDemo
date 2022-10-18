using FluentValidation;
using MCB.Core.Domain.Entities.Abstractions.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications.Interfaces;

public interface ICustomerAddressSpecifications
    : IDomainEntitySpecifications
{
    // CustomerAddressType
    public static readonly string CustomerAddressShouldHaveCustomerAddressTypeErrorCode = nameof(CustomerAddressShouldHaveCustomerAddressTypeErrorCode);
    public static readonly string CustomerAddressShouldHaveCustomerAddressTypeMessage = nameof(CustomerAddressShouldHaveCustomerAddressTypeMessage);
    public static readonly Severity CustomerAddressShouldHaveCustomerAddressTypeSeverity = Severity.Error;

    // AddressValueObject
    public static readonly string CustomerAddressShouldHaveAddressValueObjectErrorCode = nameof(CustomerAddressShouldHaveAddressValueObjectErrorCode);
    public static readonly string CustomerAddressShouldHaveAddressValueObjectMessage = nameof(CustomerAddressShouldHaveAddressValueObjectMessage);
    public static readonly Severity CustomerAddressShouldHaveAddressValueObjectSeverity = Severity.Error;

    // Methods
    bool CustomerAddressShouldHaveCustomerAddressType(CustomerAddressType customerAddressType);
    bool CustomerAddressShouldHaveAddressValueObject(AddressValueObject addressValueObject);
}