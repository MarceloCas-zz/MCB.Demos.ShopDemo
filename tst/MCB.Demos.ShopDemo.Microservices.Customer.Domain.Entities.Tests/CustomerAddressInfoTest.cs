using FluentAssertions;
using MCB.Core.Infra.CrossCutting.DateTime;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.Fixtures;
using MCB.Tests;
using System;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests
{
    [Collection(nameof(DefaultFixture))]
    public class CustomerAddressInfoTest
        : TestBase
    {
        // Fields
        private readonly DefaultFixture _fixture;

        // Constructors
        public CustomerAddressInfoTest(
            ITestOutputHelper testOutputHelper,
            DefaultFixture fixture
        ) : base(testOutputHelper)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CustomerAddressInfo_Should_Correctly_Instanciated()
        {
            // Arrange and Act
            var customerAddressInfo = new CustomerAddressInfo();

            // Assert
            customerAddressInfo.CustomerAddressCollection.Should().NotBeNull();
            customerAddressInfo.CustomerAddressCollection.Should().HaveCount(0);
            customerAddressInfo.DefaultShippingAddress.Should().BeNull();
        }

        [Fact]
        public void CustomerAddressInfo_Should_RegisterNew()
        {
            // Arrange and Act
            var customerAddressInfo = DefaultFixture.GenerateNewCustomerAddressInfo(
                existingTenantId: _fixture.TenantId,
                existingExecutionUser: _fixture.ExecutionUser,
                existingSourcePlatform: _fixture.SourcePlatform
            );

            // Assert
            customerAddressInfo.Id.Should().NotBe(Guid.Empty);
            customerAddressInfo.TenantId.Should().Be(_fixture.TenantId);

            customerAddressInfo.AuditableInfo.Should().NotBeNull();
            customerAddressInfo.AuditableInfo.CreatedAt.Should().BeAfter(default);
            customerAddressInfo.AuditableInfo.CreatedAt.Should().Be(DateTimeProvider.GetDate());
            customerAddressInfo.AuditableInfo.CreatedBy.Should().Be(_fixture.ExecutionUser);
            customerAddressInfo.AuditableInfo.UpdatedAt.Should().BeNull();
            customerAddressInfo.AuditableInfo.UpdatedBy.Should().BeNull();
            customerAddressInfo.AuditableInfo.SourcePlatform.Should().Be(_fixture.SourcePlatform);

            customerAddressInfo.RegistryVersion.Should().BeAfter(default);
            customerAddressInfo.RegistryVersion.Should().Be(DateTimeProvider.GetDate());
        }
    }
}
