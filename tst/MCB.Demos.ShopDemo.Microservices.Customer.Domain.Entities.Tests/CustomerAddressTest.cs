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
    }
}