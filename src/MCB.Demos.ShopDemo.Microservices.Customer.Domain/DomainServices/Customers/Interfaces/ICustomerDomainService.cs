using MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainServices.Base.Abstractions;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainServices.Customers.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainServices.Customers.Interfaces
{
    public interface ICustomerDomainService
        : IDomainService<Entities.Customers.Customer>
    {
        Task<bool> RegisterNewCustomerAsync(RegisterNewCustomerDomainServiceInput input, CancellationToken cancellationToken);
    }
}
