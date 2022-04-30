using FluentAssertions;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.Fixtures;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects;
using MCB.Tests;
using System;
using System.Collections.Generic;
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
            // Arrange
            var street = "dummy street";
            var number = "dummy number";
            var city = "dummy city";
            var state = "dummy state";
            var country = "dummy country";
            var zipCode = "dummy zipCode";

            foreach (var customerAddressType in Enum.GetValues<CustomerAddressType>())
            {
                var addressValueObject = new AddressValueObject(
                    street,
                    number,
                    city,
                    state,
                    country,
                    zipCode
                );

                // Act
                var customerAddress = new CustomerAddress().RegisterNew(
                    _fixture.TenantId,
                    customerAddressType,
                    addressValueObject,
                    _fixture.ExecutionUser,
                    _fixture.SourcePlatform
                );

                // Assert
                customerAddress.Id.Should().NotBe(Guid.Empty);
                customerAddress.TenantId.Should().Be(_fixture.TenantId);

                customerAddress.AuditableInfo.Should().NotBeNull();
                customerAddress.AuditableInfo.CreatedAt.Should().BeAfter(default);
                customerAddress.AuditableInfo.CreatedAt.Should().BeBefore(DateTimeOffset.UtcNow);
                customerAddress.AuditableInfo.CreatedBy.Should().Be(_fixture.ExecutionUser);
                customerAddress.AuditableInfo.UpdatedAt.Should().BeNull();
                customerAddress.AuditableInfo.UpdatedBy.Should().BeNull();
                customerAddress.AuditableInfo.SourcePlatform.Should().Be(_fixture.SourcePlatform);

                customerAddress.RegistryVersion.Should().BeAfter(default);
                customerAddress.RegistryVersion.Should().BeBefore(DateTimeOffset.UtcNow);

                customerAddress.CustomerAddressType.Should().Be(customerAddressType);
                customerAddress.AddressValueObject.Should().Be(addressValueObject);
            }
        }
    }
}