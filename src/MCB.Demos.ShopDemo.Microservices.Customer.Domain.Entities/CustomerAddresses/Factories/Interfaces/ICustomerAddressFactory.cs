using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Factory;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Factories.Interfaces;

public interface ICustomerAddressFactory
    : IFactory<CustomerAddress>
{
}