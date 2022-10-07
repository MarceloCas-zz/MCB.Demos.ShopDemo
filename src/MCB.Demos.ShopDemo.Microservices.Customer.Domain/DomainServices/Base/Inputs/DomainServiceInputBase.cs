namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.DomainServices.Base.Inputs
{
    public abstract record DomainServiceInputBase
    {
        // Properties
        public Guid TenantId { get; }
        public string ExecutionUser { get; }
        public string SourcePlatform { get; }

        // Constructors
        protected DomainServiceInputBase(Guid tenantId, string executionUser, string sourcePlatform)
        {
            TenantId = tenantId;
            ExecutionUser = executionUser;
            SourcePlatform = sourcePlatform;
        }
    }
}
