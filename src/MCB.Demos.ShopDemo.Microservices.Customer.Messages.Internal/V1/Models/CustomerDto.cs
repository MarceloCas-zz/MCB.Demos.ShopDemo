using MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.V1.Models.Base;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.V1.Models;

public class CustomerDto
    : DtoBase
{
    // Properties
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Email { get; set; }
    public CustomerAddressInfoDto? CustomerAddressInfo { get; set; }

    // Constructors
    public CustomerDto()
        : base()
    {
        FirstName = LastName = Email = string.Empty;
    }
}