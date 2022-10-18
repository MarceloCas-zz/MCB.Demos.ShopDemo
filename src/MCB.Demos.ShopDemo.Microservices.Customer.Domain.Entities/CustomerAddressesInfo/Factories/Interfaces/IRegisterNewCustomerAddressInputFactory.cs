using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Factory;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories.Interfaces;

public interface IRegisterNewCustomerAddressInputFactory
    : IFactoryWithParameter<RegisterNewCustomerAddressInput, RegisterNewCustomerAddressInfoInput>,
    IFactoryWithParameter<RegisterNewCustomerAddressInput, AddNewCustomerAddressInfoCustomerAddressInput>
{
}