using MCB.Core.Domain.Entities;
using MCB.Core.Domain.Entities.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities
{
    public class Customer
        : DomainEntityBase,
        IAggregationRoot
    {
        // Fields
        private CustomerAddressInfo _customerAddressInfo = new();

        // Properties
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateOnly BirthDate { get; private set; }

        // Navigation Properties
        public CustomerAddressInfo CustomerAddressInfo => _customerAddressInfo.DeepClone();

        // Constructors
        public Customer()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
        }

        // Public Methods
        public Customer RegisterNew(
            Guid tenantId,
            string firstName,
            string lastName,
            string executionUser,
            string sourcePlatform
        )
        {
            // Validate
            // TODO: Add validation

            // Process and Return
            return SetName(firstName, lastName)
                .RegisterNewInternal<Customer>(tenantId, executionUser, sourcePlatform);
        }
        public Customer ChangeName(
            string firstName, 
            string lastName,
            string executionUser,
            string sourcePlatform
        )
        {
            // Validate
            // TODO: Add validation

            // Process and Return
            return SetName(firstName, lastName)
                .RegisterModificationInternal<Customer>(executionUser, sourcePlatform);
        }
        public Customer ChangeBirthDate(
            DateOnly birthDate,
            string executionUser,
            string sourcePlatform
        )
        {
            // Validate
            // TODO: Add validation

            // Process and Return
            return SetBirthDate(birthDate)
                .RegisterModificationInternal<Customer>(executionUser, sourcePlatform);
        }

        // Protected Abstract Methods
        protected override DomainEntityBase CreateInstanceForCloneInternal() => new Customer();

        // Private Methods
        private Customer SetName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            return this;
        }
        private Customer SetBirthDate(DateOnly birthDate)
        {
            BirthDate = birthDate;

            return this;
        }
    }
}
