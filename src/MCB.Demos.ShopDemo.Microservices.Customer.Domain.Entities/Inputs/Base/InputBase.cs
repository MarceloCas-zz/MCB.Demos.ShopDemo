namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Inputs.Base
{
    public abstract record InputBase
    {
        public string ExecutionUser { get; }
        public string SourcePlatform { get; }

        protected InputBase(string executionUser, string sourcePlatform)
        {
            ExecutionUser = executionUser;
            SourcePlatform = sourcePlatform;
        }
    }
}
