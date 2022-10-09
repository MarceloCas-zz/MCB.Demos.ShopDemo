using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Adapter;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainRepositories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainServices.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainServices.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainServices.Customers.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Events.CustomerHasBeenRegistered.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.DomainEvents.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainServices.Customers
{
    internal class CustomerDomainService
        : DomainServiceBase<Entities.Customers.Customer>,
        ICustomerDomainService
    {
        // Fields
        private readonly ICustomerFactory _customerFactory;
        private readonly ICustomerHasBeenRegisteredDomainEventFactory _customerHasBeenRegisteredDomainEventFactory;

        // Constructors
        internal CustomerDomainService(
            INotificationPublisher notificationPublisher,
            IDomainEventPublisher domainEventPublisher,
            IAdapter adapter,
            ICustomerDomainRepository customerDomainEntityRepository,
            ICustomerFactory customerFactory,
            ICustomerHasBeenRegisteredDomainEventFactory customerHasBeenRegisteredDomainEventFactory
        ) : base(notificationPublisher, domainEventPublisher, adapter, customerDomainEntityRepository)
        {
            _customerFactory = customerFactory;
            _customerHasBeenRegisteredDomainEventFactory = customerHasBeenRegisteredDomainEventFactory;
        }

        // Public Methods
        public async Task<bool> RegisterNewCustomerAsync(RegisterNewCustomerDomainServiceInput input, CancellationToken cancellationToken)
        {
            // Validate
            // Validate is necessary to check if proposed customer not exists in repository

            // Process
            var customer = _customerFactory
                .Create()
                .RegisterNewCustomer(Adapter.Adapt<RegisterNewCustomerDomainServiceInput, RegisterNewCustomerInput>(input));

            // Validate domain entity after process
            if(!await ValidateDomainEntityAndSendNotificationsAsync(customer, cancellationToken))
                return false;

            // Persist
            if(!await DomainEntityRepository.AddAsync(customer, cancellationToken))
                return false;

            // Send domain event
            await DomainEventPublisher.PublishDomainEventAsync(
                _customerHasBeenRegisteredDomainEventFactory.Create(customer),
                cancellationToken
            );

            // Return
            return true;
        }
    }
}
