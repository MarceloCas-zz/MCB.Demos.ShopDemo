using FluentAssertions;
using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;
using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;
using MCB.Core.Infra.CrossCutting.DateTime;
using MCB.Core.Infra.CrossCutting.DependencyInjection;
using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.AddressValueObjects;
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
    // Protected Methods
    protected override IDependencyInjectionContainer CreateDependencyInjectionContainerInternal()
    {
        return new DependencyInjectionContainer();
    }
    protected override void ConfigureDependencyInjectionContainerInternal(IDependencyInjectionContainer dependencyInjectionContainer)
    {
        MCB.Core.Infra.CrossCutting.IoC.Bootstrapper.ConfigureDependencyInjection(dependencyInjectionContainer);

        DependencyInjection.Bootstrapper.ConfigureDependencyInjection(dependencyInjectionContainer);
    }
    protected override void BuildDependencyInjectionContainerInternal(IDependencyInjectionContainer dependencyInjectionContainer)
    {
        ((DependencyInjectionContainer)dependencyInjectionContainer).Build();
    }

    // Public Methods
    public AddressValueObject CreateDefaultAddressValueObject()
    {
        return new AddressValueObject(
            street: "dummy street",
            number: "dummy number",
            city: "dummy city",
            state: "dummy state",
            country: "dummy country",
            zipCode: "dummy zip code"
        );
    }
    public static void InputBaseShouldHaveSameValues(InputBase left, InputBase rigth)
    {
        left.SourcePlatform.Should().Be(rigth.SourcePlatform);
        left.TenantId.Should().Be(rigth.TenantId);
        left.ExecutionUser.Should().Be(rigth.ExecutionUser);
    }
}
