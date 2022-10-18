using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Interfaces;

public interface IChangeCustomerAddressInputShouldBeValidValidator
    : IValidator<ChangeCustomerAddressInput>
{
}