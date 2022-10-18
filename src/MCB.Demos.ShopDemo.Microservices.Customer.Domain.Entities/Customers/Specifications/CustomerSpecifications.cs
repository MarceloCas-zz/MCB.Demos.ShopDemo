using MCB.Core.Domain.Entities.DomainEntitiesBase.Specifications;
using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications;

public sealed class CustomerSpecifications
    : DomainEntitySpecifications,
    ICustomerSpecifications
{
    // Constructors
    public CustomerSpecifications(
        IDateTimeProvider dateTimeProvider
    ) : base(dateTimeProvider)
    {
    }

    // Public Methods
    public bool CustomerShouldHaveFirstName(string firstName)
    {
        return !string.IsNullOrEmpty(firstName);
    }
    public bool CustomerShouldHaveFirstNameMaximumLength(string firstName)
    {
        return firstName.Length <= 150;
    }

    public bool CustomerShouldHaveLastName(string lastName)
    {
        return !string.IsNullOrEmpty(lastName);
    }
    public bool CustomerShouldHaveLastNameMaximumLength(string lastName)
    {
        return lastName.Length <= 150;
    }

    public bool CustomerShouldHaveBirthDate(DateOnly birthDate)
    {
        return birthDate > DateOnly.MinValue;
    }
    public bool CustomerShouldHaveValidBirthDate(DateOnly birthDate)
    {
        return birthDate <= DateOnly.FromDateTime(DateTimeProvider.GetDate().Date);
    }
}