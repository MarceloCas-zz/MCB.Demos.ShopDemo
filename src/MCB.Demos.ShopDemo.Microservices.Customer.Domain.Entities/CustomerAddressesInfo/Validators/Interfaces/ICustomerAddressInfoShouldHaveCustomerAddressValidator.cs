using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators.Interfaces;

public interface ICustomerAddressInfoShouldHaveCustomerAddressValidator
    : IValidator<(Guid customerAddressId, IEnumerable<CustomerAddress> customerAddressCollection)>
{
}