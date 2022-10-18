using MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.V1.Models.Base;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.V1.Models;

public class CustomerAddressDto
    : DtoBase
{
    // Properties
    public int CustomerAddressType { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }

    // Constructors
    public CustomerAddressDto()
        : base()
    {
        Street = Number = City = State = Country = ZipCode = string.Empty;
    }
}