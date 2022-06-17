using MCB.Core.Domain.Entities.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs
{
    public record ChangeCustomerNameInput
        : InputBase
    {
        public string FirstName { get; }
        public string LastName { get; }

        public ChangeCustomerNameInput(
            Guid tenantId,
            string firstName,
            string lastName,
            string executionUser,
            string sourcePlatform
        ) : base(tenantId, executionUser, sourcePlatform)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
