using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Factory;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Factories.Interfaces;

public interface ICustomerFactory
    : IFactory<Customer>
{
}