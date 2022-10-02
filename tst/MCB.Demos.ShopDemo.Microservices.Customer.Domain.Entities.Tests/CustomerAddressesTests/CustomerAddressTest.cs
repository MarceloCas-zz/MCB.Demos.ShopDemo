using FluentAssertions;
using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;
using MCB.Core.Infra.CrossCutting.DateTime;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.Fixtures;
using MCB.Tests;
using System;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.CustomerAddressesTests
{
    [Collection(nameof(DefaultFixture))]
    public class CustomerAddressTest
        : TestBase
    {
        // Fields
        private readonly DefaultFixture _defaultFixture;

        // Constructors
        public CustomerAddressTest(
            ITestOutputHelper testOutputHelper,
            DefaultFixture defaultFixture
        ) : base(testOutputHelper)
        {
            _defaultFixture = defaultFixture;
        }

        // Protected Methods
        protected override IDateTimeProvider CreateDateTimeProvider(DateTimeOffset currentDate)
        {
            var dateTimeProvider = new DateTimeProvider();

            dateTimeProvider.ChangeGetDateCustomFunction(
                () => new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 12, minute: 0, second: 0, offset: TimeSpan.Zero)
            );

            return dateTimeProvider;
        }

        // Public Methods
        [Fact]
        public void CustomerAddress_Should_Created()
        {
            // Arrange
            var dependencyInjectionContainer = _defaultFixture.CreateNewDependencyInjectionContainer();
            var customerAddressFactory = dependencyInjectionContainer.Resolve<ICustomerAddressFactory>();

            // Act
            var customerAddress = customerAddressFactory.Create();

            // Assert
            customerAddress.Should().NotBeNull();
        }
    }
}
