using FluentAssertions;
using MCB.Core.Infra.CrossCutting.DateTime;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.Fixtures;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects;
using MCB.Tests;
using System;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests
{
    [Collection(nameof(DefaultFixture))]
    public class CustomerAddressTest
        : TestBase
    {
        // Fields
        private readonly DefaultFixture _fixture;

        // Constructors
        public CustomerAddressTest(
            ITestOutputHelper testOutputHelper,
            DefaultFixture fixture
        ) : base(testOutputHelper)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CustomerAddress_Should_Correctly_Instanciated()
        {
            // Arrange and Act
            var customerAddress = new CustomerAddress();

            // Assert
            customerAddress.CustomerAddressType.Should().Be(default);
            customerAddress.AddressValueObject.Should().Be(default(AddressValueObject));
        }

        [Fact]
        public void CustomerAddress_Should_RegisterNew()
        {
            foreach (var customerAddressType in Enum.GetValues<CustomerAddressType>())
            {
                // Arrange
                var addressValueObject = DefaultFixture.GenerateNewAddressValueObject();

                // Act
                var customerAddress = DefaultFixture.GenerateNewCustomerAddress(
                    existingTenantId: _fixture.TenantId,
                    existingCustomerAdressType: customerAddressType,
                    existingCustomerAddress: addressValueObject,
                    existingExecutionUser: _fixture.ExecutionUser,
                    existingSourcePlatform: _fixture.SourcePlatform
                );

                // Assert
                customerAddress.Id.Should().NotBe(Guid.Empty);
                customerAddress.TenantId.Should().Be(_fixture.TenantId);

                customerAddress.AuditableInfo.Should().NotBeNull();
                customerAddress.AuditableInfo.CreatedAt.Should().BeAfter(default);
                customerAddress.AuditableInfo.CreatedAt.Should().Be(DateTimeProvider.GetDate());
                customerAddress.AuditableInfo.CreatedBy.Should().Be(_fixture.ExecutionUser);
                customerAddress.AuditableInfo.UpdatedAt.Should().BeNull();
                customerAddress.AuditableInfo.UpdatedBy.Should().BeNull();
                customerAddress.AuditableInfo.SourcePlatform.Should().Be(_fixture.SourcePlatform);

                customerAddress.RegistryVersion.Should().BeAfter(default);
                customerAddress.RegistryVersion.Should().Be(DateTimeProvider.GetDate());

                customerAddress.CustomerAddressType.Should().Be(customerAddressType);
                customerAddress.AddressValueObject.Should().Be(addressValueObject);
            }
        }

        [Fact]
        public void CustomerAddress_Should_ChangeCustomerAddressType()
        {
            // Arrange
            var originalGetDataFuncion = DateTimeProvider.GetDateCustomFunction;
            DateTimeProvider.GetDateCustomFunction = () => originalGetDataFuncion().AddDays(-1);
            var customerAddress = DefaultFixture.GenerateNewCustomerAddress(existingCustomerAdressType: CustomerAddressType.HomeAddress);
            DateTimeProvider.GetDateCustomFunction = originalGetDataFuncion;

            var newCustomerAddressType = CustomerAddressType.BusinessAddress;

            var initialId = customerAddress.Id;
            var initialTenantId = customerAddress.TenantId;

            var initialCreatedAt = customerAddress.AuditableInfo.CreatedAt;
            var initialCreatedBy = customerAddress.AuditableInfo.CreatedBy;
            var initialUpdatedAt = customerAddress.AuditableInfo.UpdatedAt;
            var initialUpdatedBy = customerAddress.AuditableInfo.UpdatedBy;
            var initialSourcePlatform = customerAddress.AuditableInfo.SourcePlatform;
            var initialRegistryVersion = customerAddress.RegistryVersion;
            var initialCustomerAddressType = customerAddress.CustomerAddressType;

            // Act
            customerAddress.ChangeCustomerAddressType(newCustomerAddressType, _fixture.ExecutionUser, _fixture.SourcePlatform);

            // Assert
            customerAddress.Id.Should().Be(initialId);
            customerAddress.TenantId.Should().Be(initialTenantId);

            customerAddress.AuditableInfo.CreatedAt.Should().Be(initialCreatedAt);
            customerAddress.AuditableInfo.CreatedBy.Should().Be(initialCreatedBy);

            customerAddress.AuditableInfo.UpdatedAt.Should().NotBe(initialUpdatedAt);
            customerAddress.AuditableInfo.UpdatedAt.Should().Be(DateTimeProvider.GetDate());

            customerAddress.AuditableInfo.UpdatedBy.Should().NotBe(initialUpdatedBy);
            customerAddress.AuditableInfo.UpdatedBy.Should().Be(_fixture.ExecutionUser);

            customerAddress.AuditableInfo.SourcePlatform.Should().NotBe(initialSourcePlatform);
            customerAddress.AuditableInfo.SourcePlatform.Should().Be(_fixture.SourcePlatform);

            customerAddress.RegistryVersion.Should().NotBe(initialRegistryVersion);
            customerAddress.RegistryVersion.Should().Be(DateTimeProvider.GetDate());

            customerAddress.CustomerAddressType.Should().NotBe(initialCustomerAddressType);
            customerAddress.CustomerAddressType.Should().Be(newCustomerAddressType);
        }

        [Fact]
        public void CustomerAddress_Should_ChangeAddress()
        {
            // Arrange
            var originalGetDataFuncion = DateTimeProvider.GetDateCustomFunction;
            DateTimeProvider.GetDateCustomFunction = () => originalGetDataFuncion().AddDays(-1);
            var customerAddress = DefaultFixture.GenerateNewCustomerAddress(existingCustomerAddress: DefaultFixture.GenerateNewAddressValueObject());
            DateTimeProvider.GetDateCustomFunction = originalGetDataFuncion;

            var newCustomerAddress = DefaultFixture.GenerateNewAddressValueObject();

            var initialId = customerAddress.Id;
            var initialTenantId = customerAddress.TenantId;

            var initialCreatedAt = customerAddress.AuditableInfo.CreatedAt;
            var initialCreatedBy = customerAddress.AuditableInfo.CreatedBy;
            var initialUpdatedAt = customerAddress.AuditableInfo.UpdatedAt;
            var initialUpdatedBy = customerAddress.AuditableInfo.UpdatedBy;
            var initialSourcePlatform = customerAddress.AuditableInfo.SourcePlatform;
            var initialRegistryVersion = customerAddress.RegistryVersion;
            var initialCustomerAddressType = customerAddress.CustomerAddressType;

            // Act
            customerAddress.ChangeAddress(newCustomerAddress, _fixture.ExecutionUser, _fixture.SourcePlatform);

            // Assert
            customerAddress.Id.Should().Be(initialId);
            customerAddress.TenantId.Should().Be(initialTenantId);

            customerAddress.AuditableInfo.CreatedAt.Should().Be(initialCreatedAt);
            customerAddress.AuditableInfo.CreatedBy.Should().Be(initialCreatedBy);

            customerAddress.AuditableInfo.UpdatedAt.Should().NotBe(initialUpdatedAt);
            customerAddress.AuditableInfo.UpdatedAt.Should().Be(DateTimeProvider.GetDate());

            customerAddress.AuditableInfo.UpdatedBy.Should().NotBe(initialUpdatedBy);
            customerAddress.AuditableInfo.UpdatedBy.Should().Be(_fixture.ExecutionUser);

            customerAddress.AuditableInfo.SourcePlatform.Should().NotBe(initialSourcePlatform);
            customerAddress.AuditableInfo.SourcePlatform.Should().Be(_fixture.SourcePlatform);

            customerAddress.RegistryVersion.Should().NotBe(initialRegistryVersion);
            customerAddress.RegistryVersion.Should().Be(DateTimeProvider.GetDate());

            customerAddress.AddressValueObject.Should().NotBe(initialCustomerAddressType);
            customerAddress.AddressValueObject.Should().Be(newCustomerAddress);
        }

        [Fact]
        public void CustomerAddress_Should_ChangeFullAddressInfo()
        {
            // Arrange
            var originalGetDataFuncion = DateTimeProvider.GetDateCustomFunction;
            DateTimeProvider.GetDateCustomFunction = () => originalGetDataFuncion().AddDays(-1);
            var customerAddress = DefaultFixture.GenerateNewCustomerAddress(existingCustomerAddress: DefaultFixture.GenerateNewAddressValueObject());
            DateTimeProvider.GetDateCustomFunction = originalGetDataFuncion;

            var newCustomerAddress = DefaultFixture.GenerateNewAddressValueObject();
            var newCustomerAddressType = CustomerAddressType.BusinessAddress;

            var initialId = customerAddress.Id;
            var initialTenantId = customerAddress.TenantId;

            var initialCreatedAt = customerAddress.AuditableInfo.CreatedAt;
            var initialCreatedBy = customerAddress.AuditableInfo.CreatedBy;
            var initialUpdatedAt = customerAddress.AuditableInfo.UpdatedAt;
            var initialUpdatedBy = customerAddress.AuditableInfo.UpdatedBy;
            var initialSourcePlatform = customerAddress.AuditableInfo.SourcePlatform;
            var initialRegistryVersion = customerAddress.RegistryVersion;
            var initialCustomerAddressType = customerAddress.CustomerAddressType;
            var initialAddressValueObject = customerAddress.AddressValueObject;

            // Act
            customerAddress.ChangeFullAddressInfo(newCustomerAddressType, newCustomerAddress, _fixture.ExecutionUser, _fixture.SourcePlatform);

            // Assert
            customerAddress.Id.Should().Be(initialId);
            customerAddress.TenantId.Should().Be(initialTenantId);

            customerAddress.AuditableInfo.CreatedAt.Should().Be(initialCreatedAt);
            customerAddress.AuditableInfo.CreatedBy.Should().Be(initialCreatedBy);

            customerAddress.AuditableInfo.UpdatedAt.Should().NotBe(initialUpdatedAt);
            customerAddress.AuditableInfo.UpdatedAt.Should().Be(DateTimeProvider.GetDate());

            customerAddress.AuditableInfo.UpdatedBy.Should().NotBe(initialUpdatedBy);
            customerAddress.AuditableInfo.UpdatedBy.Should().Be(_fixture.ExecutionUser);

            customerAddress.AuditableInfo.SourcePlatform.Should().NotBe(initialSourcePlatform);
            customerAddress.AuditableInfo.SourcePlatform.Should().Be(_fixture.SourcePlatform);

            customerAddress.RegistryVersion.Should().NotBe(initialRegistryVersion);
            customerAddress.RegistryVersion.Should().Be(DateTimeProvider.GetDate());

            customerAddress.AddressValueObject.Should().NotBe(initialCustomerAddressType);
            customerAddress.AddressValueObject.Should().Be(newCustomerAddress);

            customerAddress.CustomerAddressType.Should().NotBe(initialCustomerAddressType);
            customerAddress.CustomerAddressType.Should().Be(newCustomerAddressType);
        }
    }
}