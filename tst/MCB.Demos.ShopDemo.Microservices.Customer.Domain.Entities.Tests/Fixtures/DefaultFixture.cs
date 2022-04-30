using MCB.Tests.Fixtures;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.Fixtures
{
    [CollectionDefinition(nameof(DefaultFixture))]
    public class DefaultFixtureCollection
        : ICollectionFixture<DefaultFixture>
    {

    }

    public class DefaultFixture
        : FixtureBase
    {
        // Properties
        public Guid TenantId { get; }
        public string ExecutionUser { get; }
        public string SourcePlatform { get; }

        // Constructors
        public DefaultFixture()
        {
            TenantId = Guid.Parse("{DC09FAEC-F5C5-49F1-82EE-9856B3D7D288}");
            ExecutionUser = "marcelo.castelo@outlook.com";
            SourcePlatform = "UnitTest";
        }

        protected override void ConfigureServices(ServiceCollection services)
        {

        }
    }
}
