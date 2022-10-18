using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Interfaces;

public interface ICustomerAddressShouldBeValidValidator
    : IValidator<CustomerAddress>
{
}