using MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainRepositories.Base.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainRepositories.Interfaces;

public interface ICustomerDomainRepository
    : IDomainRepository<Entities.Customers.Customer>
{
}
