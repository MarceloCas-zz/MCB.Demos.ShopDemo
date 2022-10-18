namespace MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.Base.Input;

public abstract record UseCaseInputBase
{
    // Properties
    public Guid TenantId { get; }
    public string ExecutionUser { get; }
    public string SourcePlatform { get; }

    // Constructors
    protected UseCaseInputBase(Guid tenantId, string executionUser, string sourcePlatform)
    {
        TenantId = tenantId;
        ExecutionUser = executionUser;
        SourcePlatform = sourcePlatform;
    }
}