using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Factory;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories.Interfaces;

public interface IRemoveCustomerAddressInfoCustomerAddressInputFactory
    : IFactoryWithParameter<RemoveCustomerAddressInfoCustomerAddressInput, RemoveCustomerAddressInput>
{
}