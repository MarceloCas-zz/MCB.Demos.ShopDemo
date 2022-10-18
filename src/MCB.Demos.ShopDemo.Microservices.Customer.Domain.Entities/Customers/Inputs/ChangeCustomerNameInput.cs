using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;

public sealed record ChangeCustomerNameInput
    : InputBase
{
    // Properties
    public string FirstName { get; }
    public string LastName { get; }

    // Constructors
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