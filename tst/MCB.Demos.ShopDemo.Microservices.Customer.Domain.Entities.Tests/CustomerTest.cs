using FluentAssertions;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.Fixtures;
using MCB.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests
{
    [Collection(nameof(DefaultFixture))]
    public class CustomerTest
        : TestBase
    {
        // Fields
        private readonly DefaultFixture _fixture;

        // Constructors
        public CustomerTest(
            ITestOutputHelper testOutputHelper,
            DefaultFixture fixture
        ) : base(testOutputHelper)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Customer_Should_Correctly_Instanciated()
        {
            // Arrange and Act
            var customer = new Customer();

            // Assert
            customer.FirstName.Should().BeNullOrEmpty();
            customer.LastName.Should().BeNullOrEmpty();
            customer.BirthDate.Should().Be(default);
            customer.CustomerAddressInfo.Should().NotBeNull();
        }
    }
}
