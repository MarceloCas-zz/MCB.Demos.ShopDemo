using FluentAssertions;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.Fixtures;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.AddressValueObjects;
using MCB.Tests;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.ValueObjectsTests
{
    [Collection(nameof(DefaultFixture))]
    public class AddressValueObjectTest
        : TestBase
    {
        // Fields
        private readonly DefaultFixture _fixture;

        // Constructors
        public AddressValueObjectTest(
            ITestOutputHelper testOutputHelper,
            DefaultFixture fixture
        ) : base(testOutputHelper)
        {
            _fixture = fixture;
        }

        [Fact]
        public void AddressValueObject_Should_Correctly_Initialized()
        {
            // Arrange
            var street = "street";
            var number = "number";
            var city = "city";
            var state = "state";
            var country = "country";
            var zipCode = "zipCode";

            // Act
            var addressValueObject = new AddressValueObject(
                street,
                number,
                city,
                state,
                country,
                zipCode
            );

            // Assert
            addressValueObject.Street.Should().Be(street);
            addressValueObject.Number.Should().Be(number);
            addressValueObject.City.Should().Be(city);
            addressValueObject.State.Should().Be(state);
            addressValueObject.Country.Should().Be(country);
            addressValueObject.ZipCode.Should().Be(zipCode);
        }
    }
}
