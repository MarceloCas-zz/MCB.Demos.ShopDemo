namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address;

public struct AddressValueObject
{
    // Properties
    public string Street { get; }
    public string Number { get; }
    public string City { get; }
    public string State { get; }
    public string Country { get; }
    public string ZipCode { get; }

    // Constructors
    public AddressValueObject(
        string street,
        string number,
        string city,
        string state,
        string country,
        string zipCode
    )
    {
        Street = street;
        Number = number;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }
}