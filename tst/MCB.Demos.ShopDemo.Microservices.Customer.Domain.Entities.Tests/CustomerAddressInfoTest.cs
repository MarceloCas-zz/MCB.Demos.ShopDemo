using FluentAssertions;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.Fixtures;
using MCB.Tests;
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
            ValidateAfterRegisterNew(customerAddressInfo, _fixture.ExecutionUser, _fixture.SourcePlatform);
        }

        [Fact]
        public void CustomerAddressInfo_Should_ChangeDefaultShippingAddress()
        {
            // Arrange
            var customerAddressInfo = DefaultFixture.GenerateNewCustomerAddressInfo(
                existingTenantId: _fixture.TenantId,
                existingExecutionUser: _fixture.ExecutionUser,
                existingSourcePlatform: _fixture.SourcePlatform
            );
            var customerAddress = DefaultFixture.GenerateNewCustomerAddress();

            // Act
            customerAddressInfo.ChangeDefaultShippingAddress(
                customerAddress,
                _fixture.ExecutionUser,
                _fixture.SourcePlatform
            );

            // Assert
            customerAddressInfo.DefaultShippingAddress.Should().NotBeNull();
            customerAddressInfo.DefaultShippingAddress.Should().NotBeSameAs(customerAddress);
            DefaultFixture.CompareTwoCustomerAddressValues(customerAddressInfo.DefaultShippingAddress, customerAddress).Should().BeTrue();
        }

        [Fact]
        public void CustomerAddressInfo_Should_ClearDefaultShippingAddress()
        {
            // Arrange
            var customerAddressInfo = DefaultFixture.GenerateNewCustomerAddressInfo(
                existingTenantId: _fixture.TenantId,
                existingExecutionUser: _fixture.ExecutionUser,
                existingSourcePlatform: _fixture.SourcePlatform
            );
            var customerAddress = DefaultFixture.GenerateNewCustomerAddress();
            customerAddressInfo.ChangeDefaultShippingAddress(
                customerAddress,
                _fixture.ExecutionUser,
                _fixture.SourcePlatform
            );
            var initialDefaultShippingAddress = customerAddressInfo.DefaultShippingAddress;

            // Act
            customerAddressInfo.ClearDefaultShippingAddress(
                _fixture.ExecutionUser,
                _fixture.SourcePlatform
            );

            // Assert
            customerAddressInfo.DefaultShippingAddress.Should().NotBeNull();
            customerAddressInfo.DefaultShippingAddress.Should().NotBeSameAs(customerAddress);
            DefaultFixture.CompareTwoCustomerAddressValues(customerAddressInfo.DefaultShippingAddress, customerAddress).Should().BeTrue();
        }
    }
}
