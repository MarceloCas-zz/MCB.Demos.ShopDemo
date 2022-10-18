namespace MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.V1.Models.Base;

public abstract class DtoBase
{
    // Properties
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public string CreatedBy { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? LastUpdatedBy { get; set; }
    public DateTimeOffset? LastUpdatedAt { get; set; }
    public string? LastSourcePlatform { get; set; }
    public DateTimeOffset RegistryVersion { get; set; }

    // Constructors
    protected DtoBase()
    {
        CreatedBy = string.Empty;
    }
}