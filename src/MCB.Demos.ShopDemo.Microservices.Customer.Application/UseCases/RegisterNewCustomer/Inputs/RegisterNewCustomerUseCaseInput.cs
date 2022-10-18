using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.Base.Input;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.RegisterNewCustomer.Inputs;

public record RegisterNewCustomerUseCaseInput
    : UseCaseInputBase
{
    // Properties
    public string FirstName { get; }
    public string LastName { get; }
    public DateOnly BirthDate { get; }
    public string Email { get; }

    public RegisterNewCustomerUseCaseInput(
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