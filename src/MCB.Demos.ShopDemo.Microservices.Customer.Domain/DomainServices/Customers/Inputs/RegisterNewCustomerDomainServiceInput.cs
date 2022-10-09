using MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainServices.Base.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainServices.Customers.Inputs;

public record RegisterNewCustomerDomainServiceInput
    : DomainServiceInputBase
{
    // Properties
    public string FirstName { get; }
    public string LastName { get; }
    public DateOnly BirthDate { get; }

    public RegisterNewCustomerDomainServiceInput(
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
