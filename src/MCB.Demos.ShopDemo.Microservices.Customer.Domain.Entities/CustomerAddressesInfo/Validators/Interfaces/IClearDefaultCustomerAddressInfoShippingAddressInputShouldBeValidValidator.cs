using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators.Interfaces;

public interface IClearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator
    : IValidator<ClearDefaultCustomerAddressInfoShippingAddressInput>
{
}