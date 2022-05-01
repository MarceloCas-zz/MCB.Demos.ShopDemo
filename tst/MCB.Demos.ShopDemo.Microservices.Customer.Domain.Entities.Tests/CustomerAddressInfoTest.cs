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
    }
}
