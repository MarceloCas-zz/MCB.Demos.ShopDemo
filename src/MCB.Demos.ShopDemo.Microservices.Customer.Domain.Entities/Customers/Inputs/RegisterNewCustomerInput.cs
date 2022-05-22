using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Base.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs
{
    public record RegisterNewCustomerInput
        : InputBase
    {
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
        ) : base(tenantId, executionUser, sourcePlatform)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }
    }
}
