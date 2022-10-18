using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Factory;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Factories.Interfaces;

public interface IChangeCustomerFullAddressInfoInputFactory
    : IFactoryWithParameter<ChangeCustomerFullAddressInfoInput, ChangeCustomerAddressInfoCustomerAddressInput>
{
}