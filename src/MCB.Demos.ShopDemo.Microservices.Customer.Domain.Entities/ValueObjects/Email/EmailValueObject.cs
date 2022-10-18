namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Email;

public struct EmailValueObject
{
    // Properties
    public string Address { get; }

    // Constructors
    public EmailValueObject(string address)
    {
        Address = address;
    }

    // Operators
    public static implicit operator string(EmailValueObject emailValueObject) => emailValueObject.Address;
    public static implicit operator EmailValueObject(string address) => new(address);
}