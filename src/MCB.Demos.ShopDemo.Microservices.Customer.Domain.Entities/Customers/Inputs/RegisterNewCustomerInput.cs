using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;

public sealed record RegisterNewCustomerInput
    : InputBase
{
    // Properties
    public string FirstName { get; }
    public string LastName { get; }
    public DateOnly BirthDate { get; }
    public string Email { get; }

    // Constructors
    public RegisterNewCustomerInput(
        Guid tenantId,
        string firstName,
        string lastName,
        DateOnly birthDate,
        string email,
        string executionUser,
        string sourcePlatform
    ) : base(tenantId, executionUser, sourcePlatform)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Email = email;
    }
}