using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;

public sealed record ChangeCustomerDefaultShippingAddressInput
    : InputBase
{
    // Properties
    public Guid CustomerAddressId { get; }

    // Constructors
    public ChangeCustomerDefaultShippingAddressInput(
        Guid tenantId,
        Guid customerAddressId,
        string executionUser,
        string sourcePlatform
    ) : base(tenantId, executionUser, sourcePlatform)
    {
        CustomerAddressId = customerAddressId;
    }
}