using MCB.Core.Infra.CrossCutting.DependencyInjection;
using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Interfaces;
using MCB.Tests.Fixtures;
using Xunit;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.Fixtures;

[CollectionDefinition(nameof(DefaultFixture))]
public class DefaultFixtureCollection
    : ICollectionFixture<DefaultFixture>
{

}

public class DefaultFixture
    : FixtureBase
{
    protected override IDependencyInjectionContainer CreateDependencyInjectionContainerInternal()
    {
        return new DependencyInjectionContainer();
    }
    protected override void ConfigureDependencyInjectionContainerInternal(IDependencyInjectionContainer dependencyInjectionContainer)
    {

    }
    protected override void BuildDependencyInjectionContainerInternal(IDependencyInjectionContainer dependencyInjectionContainer)
    {

    }
}
