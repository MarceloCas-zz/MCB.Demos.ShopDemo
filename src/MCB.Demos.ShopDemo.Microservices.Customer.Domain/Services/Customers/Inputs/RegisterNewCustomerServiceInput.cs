using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Services.Base.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Services.Customers.Inputs;

public record RegisterNewCustomerServiceInput
    : ServiceInputBase
{
    // Properties
    public string FirstName { get; }
    public string LastName { get; }
    public DateOnly BirthDate { get; }
    public string Email { get; }

    public RegisterNewCustomerServiceInput(
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