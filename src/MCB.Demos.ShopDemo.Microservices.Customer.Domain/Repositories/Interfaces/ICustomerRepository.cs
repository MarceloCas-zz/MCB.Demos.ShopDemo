using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Repositories.Base.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Repositories.Interfaces;

public interface ICustomerRepository
    : IRepository<Entities.Customers.Customer>
{
}
