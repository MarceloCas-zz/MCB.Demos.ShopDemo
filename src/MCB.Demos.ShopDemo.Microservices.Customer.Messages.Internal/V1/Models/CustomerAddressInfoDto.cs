using MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.V1.Models.Base;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.V1.Models;

public class CustomerAddressInfoDto
    : DtoBase
{
    // Properties
    public CustomerAddressDto[] CustomerAddressCollection { get; set; }
    public CustomerAddressDto? DefaultShippingAddressDto { get; set; }

    // Constructors
    public CustomerAddressInfoDto()
        : base()
    {
        CustomerAddressCollection = Array.Empty<CustomerAddressDto>();
    }

}