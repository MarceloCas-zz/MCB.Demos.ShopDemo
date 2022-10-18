using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;

public interface IClearCustomerDefaultShippingAddressInputShouldBeValidValidator
    : IValidator<ClearCustomerDefaultShippingAddressInput>
{
}