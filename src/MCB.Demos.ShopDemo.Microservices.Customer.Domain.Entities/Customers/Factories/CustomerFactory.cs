using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Factories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Factories
{
    public class CustomerFactory
        : ICustomerFactory
    {
        // Properties
        protected IServiceProvider ServiceProvider { get; }

        // Constructors
        public CustomerFactory(
            IServiceProvider serviceProvider
        )
        {
            ServiceProvider = serviceProvider;
        }

        // Public Methods
        public Customer Create()
        {
            return ServiceProvider.GetService<Customer>();
        }
    }
}
