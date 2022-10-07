using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Adapter;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainRepositories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainServices.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainServices.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainServices.Customers.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainServices.Customers
{
    internal class CustomerDomainService
        : DomainServiceBase<Entities.Customers.Customer>,
        ICustomerDomainService
    {
        // Fields
        private readonly ICustomerFactory _customerFactory;

        // Constructors
        internal CustomerDomainService(
            INotificationPublisher notificationPublisher,
            IAdapter adapter,
            ICustomerDomainRepository customerDomainEntityRepository,
            ICustomerFactory customerFactory
        ) : base(notificationPublisher, adapter, customerDomainEntityRepository)
        {
            _customerFactory = customerFactory;
        }

        // Public Methods
        public async Task<bool> RegisterNewCustomerAsync(RegisterNewCustomerDomainServiceInput input, CancellationToken cancellationToken)
        {
            // Validate
            // Validate is necessary to check if proposed customer not exists in repository

            // Process
            var customer = _customerFactory.Create();
            customer.RegisterNewCustomer(Adapter.Adapt<RegisterNewCustomerDomainServiceInput, RegisterNewCustomerInput>(input));

            // Validate Process
            if(!customer.ValidationInfo.IsValid)
            {
                // Send notifications
                return false;
            }

            // Persist
            var persistenceResult = await DomainEntityRepository.AddAsync(customer, cancellationToken);
            if(!persistenceResult)
            {
                // Send notifications
                return false;
            }

            // Send domain event

            // Return
            return persistenceResult;
        }
    }
}
