using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Inputs.Base;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs
{
    public record RegisterNewCustomerInput
        : InputBase
    {
        public Guid TenantId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateOnly BirthDate { get; }

        public RegisterNewCustomerInput(
            Guid tenantId,
            string firstName,
            string lastName,
            DateOnly birthDate,
            string executionUser,
            string sourcePlatform
        ) : base(executionUser, sourcePlatform)
        {
            TenantId = tenantId;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }
    }
}
